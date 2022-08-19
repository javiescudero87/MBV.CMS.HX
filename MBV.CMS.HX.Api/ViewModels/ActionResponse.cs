using Newtonsoft.Json;

namespace MBV.CMS.HX.Api.ViewModels
{
    public class IncorporationActionResponse
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("tool_id")]
        public string ToolId { get; internal set; }

        [JsonProperty("brand")]
        public string? Brand { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("status")]
        public StatusResponse Status { get; set; }
    }
}