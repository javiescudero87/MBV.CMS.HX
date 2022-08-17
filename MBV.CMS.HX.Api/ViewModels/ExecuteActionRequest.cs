using Newtonsoft.Json;

namespace MBV.CMS.HX.Api.ViewModels
{
    public class ExecuteActionRequest
    {
        [JsonProperty("tool_id")]
        public string ToolId { get; internal set; }

        [JsonProperty("location")]
        public string Location { get; internal set; }
    }
}
