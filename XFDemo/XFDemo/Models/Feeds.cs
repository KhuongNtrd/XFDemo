using Newtonsoft.Json;

namespace XFDemo.Models
{
    public partial class Feeds
    {
        [JsonProperty("posts")]
        public Posts Posts { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
