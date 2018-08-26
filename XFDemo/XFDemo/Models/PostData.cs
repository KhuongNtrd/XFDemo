using Newtonsoft.Json;

namespace XFDemo.Models
{
    public partial class PostData
    {
        [JsonProperty("full_picture", NullValueHandling = NullValueHandling.Ignore)]
        public string FullPicture { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
        public bool HasPicture => !string.IsNullOrEmpty(FullPicture);
    }
}
