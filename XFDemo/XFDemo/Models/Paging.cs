using Newtonsoft.Json;

namespace XFDemo.Models
{
    public partial class Paging
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
