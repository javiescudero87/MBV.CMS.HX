using Correlate.AspNetCore;
using Correlate.DependencyInjection;
using HealthChecks.UI.Client;
using MBV.CMS.HX.Api.Clients;
using MBV.CMS.HX.Api.Filters;
using MBV.CMS.HX.Api.Middleware;
using MBV.CMS.HX.Api.Models;
using MBV.CMS.HX.Api.Swagger;
using MBV.CMS.HX.Common;
using MBV.CMS.HX.Common.Configurations;
using MBV.CMS.HX.DataAccess.Interface;
using MBV.CMS.HX.DataAccess.NHibernate;
using MBV.CMS.HX.DataAccess.NHibernate.Extensions;
using MBV.CMS.HX.Service;
using MBV.CMS.HX.Service.Interface;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(ModelStateValidateAttribute), 1);
        options.Filters.Add(typeof(ExceptionsAttribute), 2);
        options.Filters.Add(typeof(TransactionAttribute), 3);
        options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorDetailModel), StatusCodes.Status422UnprocessableEntity));
        options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorDetailModel), StatusCodes.Status500InternalServerError));
    })
    .AddNewtonsoftJson();


#region Serilog

builder.Host.UseSerilog((_, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithMachineName()
    .Enrich.WithCorrelationIdHeader(AppConstants.XCorrelationIdName)
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
        .WithDefaultDestructurers()
        .WithDestructurers(new[] { new DbUpdateExceptionDestructurer() }))
    .WriteTo.Debug()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"));

#endregion

#region Services for Hibernate

builder.Services.AddNHibernate(builder.Configuration["ConnectionStrings:DefaultConnection"]);

#endregion

#region Correlation Ids

builder.Services.AddCorrelate(options => options.RequestHeaders = new[] { AppConstants.XCorrelationIdName });

#endregion Correlation Ids

#region Servicio de Logs Request/Response

builder.Services.AddTransient<RequestResponseLoggingMiddleware>();

#endregion Servicio de Logs Request/Response

#region HttpClient Configurations

builder.Services.AddHttpClientConfiguration(builder.Configuration);

#endregion

#region Propagacion de Headers

builder.Services.AddHeaderPropagation(options =>
{
    options.Headers.Add(AppConstants.UserHeaderName);
    options.Headers.Add(AppConstants.ChannelHeaderName);
    options.Headers.Add(AppConstants.ApplicationHeaderName);
});

#endregion Propagacion de Headers

#region Versionado de la Api

builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddApiVersioning(
    options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
    });

#endregion Versionado de la Api

#region Configuracion ApiBehaviorOptions

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressConsumesConstraintForFormFileParameters = true;
});

#endregion Configuracion ApiBehaviorOptions

#region Autommaper

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));

#endregion

#region Open Api (swagger)

builder.Services.AddSwaggerGenForService();

builder.Services.AddSwaggerGenNewtonsoftSupport();

#endregion Open Api (swagger)

#region HealthChecks

builder.Services.AddHealthChecks()
    .AddSqlServer(
    connectionString: builder.Configuration["ConnectionStrings:DefaultConnection"],
    healthQuery: "SELECT 1;",
    name: "Sql Server",
    failureStatus: HealthStatus.Unhealthy,
    tags: new[] { "db", "sql", "sqlserver" });

builder.Services.AddHealthChecksUI().AddInMemoryStorage();



#endregion

#region IOption

builder.Services.Configure<OpenApiInfoConfigurationOptions>(builder.Configuration.GetSection("OpenApiInfo"));

#endregion IOption

#region Configuration Injection Dependency

builder.Services.AddTransient<IMBCarRepository, MBCarRepository>();
builder.Services.AddTransient<IMBCarService, MBCarService>();
builder.Services.AddTransient<IToolActionRepository, ToolActionRepository>();
builder.Services.AddTransient<IToolActionService, ToolActionService>();

#endregion

var app = builder.Build();

app.UseCorrelate();
app.UseHeaderPropagation();

app.UseRequestResponseLogging();

app.UseSwagger(c => { c.SerializeAsV2 = true; });
app.UseSwaggerUI(app.Services.GetRequiredService<IApiVersionDescriptionProvider>().SwaggerOptionUi);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(config =>
{
    config.MapHealthChecksUI(options =>
    {
        options.UIPath = "/health-ui";
    });
    config.MapHealthChecks("/healthz", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});


app.UseHealthChecks("/health");


app.Run();
