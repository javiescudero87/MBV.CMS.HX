using Newtonsoft.Json;

namespace MBV.CMS.HX.Api.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MBCarCreateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }
    }
}
