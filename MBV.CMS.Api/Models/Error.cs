using Newtonsoft.Json;

namespace MBV.CMS.Api.Models
{
    /// <summary>
    /// Error
    /// </summary>
    [JsonObject(Title = "error")]
    public class Error
    {
        /// <summary>
        /// Code
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Detail
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; } = string.Empty;
    }
}
