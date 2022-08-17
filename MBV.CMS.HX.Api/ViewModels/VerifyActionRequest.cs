using Newtonsoft.Json;

namespace MBV.CMS.HX.Api.ViewModels
{
    public class VerifyActionRequest
    {
        [JsonProperty("evidence")]
        public string Evidence { get; set; }
    }
}
