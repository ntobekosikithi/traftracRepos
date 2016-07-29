using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TrafBoot.Models
{
    public class resultsItem
    {
        [JsonProperty("?xml")]
        public XmlItem encoding { get; set; }

        [JsonProperty("rss")]
        public RssItem rss { get; set; }
    }

    public class XmlItem
    {
        [JsonProperty("@version")]
        public string version { get; set; }

        [JsonProperty("@encoding")]
        public string encoding { get; set; }
    }

    public class RssItem
    {
        [JsonProperty("@xmlns:a10")]
        public string xmlnsa10 { get; set; }
        [JsonProperty("@version")]
        public string version { get; set; }
        public ChannelItem channel { get; set; }
    }

    public class ChannelItem
    {
        public string title { get; set; }
        public string description { get; set; }
        public ItemItem item { get; set; }
    }

    public class ItemItem
    {
        public string link { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
    }
}