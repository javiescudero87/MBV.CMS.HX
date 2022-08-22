using Newtonsoft.Json;

namespace MBV.CMS.Api.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ExampleResponse
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
