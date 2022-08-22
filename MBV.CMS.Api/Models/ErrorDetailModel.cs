using Newtonsoft.Json;

namespace MBV.CMS.Api.Models
{
    /// <summary>
    /// ErrorDetailModel
    /// </summary>
    [JsonObject(Title = "detalle_error_model")]
    public class ErrorDetailModel
    {
        /// <summary>
        /// ErrorDetailModel constructor
        /// </summary>
        public ErrorDetailModel()
        {
            Errors = new List<Error>();
        }

        /// <summary>
        /// Http error status description
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; set; } = string.Empty;

        /// <summary>
        /// Error detail
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; } = string.Empty;

        /// <summary>
        /// Correlation Id
        /// </summary>
        [JsonProperty(PropertyName = "correlation_id")]
        public string CorrelationId { get; set; } = string.Empty;

        /// <summary>
        /// Errors list
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public List<Error> Errors { get; set; }
    }
}
