using Newtonsoft.Json;

namespace MBV.CMS.Api.ViewModels
{
    public class StatusResponse
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
