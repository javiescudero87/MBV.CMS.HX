using Newtonsoft.Json;

namespace MBV.CMS.Api.ViewModels
{
    public class IncorporationActionRequest
    {

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }
}