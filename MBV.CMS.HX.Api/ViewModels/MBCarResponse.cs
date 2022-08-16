using Newtonsoft.Json;

namespace MBV.CMS.HX.Api.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MBCarResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
