using Newtonsoft.Json;

namespace XFDemo.Models
{
    public partial class Picture
    {
        [JsonProperty("data")]
        public PictureData Data { get; set; }
    }
}
