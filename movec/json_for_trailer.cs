using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class RootObjectForTrailerData
    {
        [JsonProperty("IMDbId")]
        public string imdbID { get; set; }

        [JsonProperty("Title")]
        public string title { get; set; }

        [JsonProperty("FullTitle")]
        public string fullTitle { get; set; }

        [JsonProperty("Type")]
        public string type { get; set; }

        [JsonProperty("Year")]
        public string year { get; set; }

        [JsonProperty("VideoId")]
        public string videoID { get; set; }

        [JsonProperty("VideoTitle")]
        public string videoTitle { get; set; }

        [JsonProperty("VideoDescription")]
        public string VideoDescription { get; set; }

        [JsonProperty("ThumbnaiUrl")]
        public string thumbnailUrl { get; set; }

        [JsonProperty("UploadDate")]
        public string uploadDate { get; set; }

        [JsonProperty("Link")]
        public string link { get; set; }

        [JsonProperty("LinkEmbed")]
        public string linkEmbed { get; set; }

        [JsonProperty("ErrorMessage")]
        public string errorMessage { get; set; }
    }
}
