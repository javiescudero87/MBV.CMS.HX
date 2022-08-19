using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MBV.CMS.HX.DataAccess.NHibernate.Mappings;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace MBV.CMS.HX.DataAccess.NHibernate.Extensions
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var fluentConfig = Fluently.Configure()
                .Mappings(mapper =>
                {
                    mapper.FluentMappings.Add<MBCarMapping>();
                    mapper.FluentMappings.Add<IncorporationToolActionMapping>();
                })
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString))
                .ExposeConfiguration(x =>
                {
                    x.SetProperty("dialect", typeof(MsSql2012Dialect).AssemblyQualifiedName);
                    x.SetProperty("connection.release_mode", "on_close");
                }).BuildConfiguration();


            var sessionFactory = fluentConfig.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(session => sessionFactory.OpenSession());

            //Uncomment to create DB schema from entities
                new SchemaExport(fluentConfig).Execute(useStdOut: false, execute: true, justDrop: false, connection: sessionFactory.OpenSession().Connection, exportOutput: Console.Out);

            return services;
        }
    }
}
