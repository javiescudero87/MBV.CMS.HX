using Newtonsoft.Json;

namespace MBV.CMS.Api.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ExampleCreateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }
    }
}
