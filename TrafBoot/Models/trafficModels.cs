using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TrafBoot.Models
{
    public class results
    {
        [JsonProperty("?xml")]
        public Xml encoding { get; set; }

        [JsonProperty("rss")]
        public Rss rss { get; set; }
    }

    public class Xml
    {
        [JsonProperty("@version")]
        public string version { get; set; }

        [JsonProperty("@encoding")]
        public string encoding { get; set; }
    }

    public class Rss
    {
        [JsonProperty("@xmlns:a10")]
        public string xmlnsa10 { get; set; }
        [JsonProperty("@version")]
        public string version { get; set; }
        public Channel channel { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<Item> item { get; set; }
    }

    public class Item
    {
        public string link { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
    }
}