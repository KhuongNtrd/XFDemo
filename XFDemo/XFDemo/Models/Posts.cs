using Newtonsoft.Json;
using System.Collections.Generic;

namespace XFDemo.Models
{
    public partial class Posts
    {
        [JsonProperty("data")]
        public List<PostData> Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
