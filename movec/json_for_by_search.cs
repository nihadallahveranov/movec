using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class RootObjectForBySearch
    {
        [JsonProperty("Search")]
        public List<Search> search { get; set; }

        [JsonProperty("totalResults")]
        public string totalResults { get; set; }

        [JsonProperty("Response")]
        public string response { get; set; }
    }

    class Search
    {
        [JsonProperty("Title")]
        public string title { get; set; }

        [JsonProperty("Year")]
        public string year { get; set; }

        [JsonProperty("imdbID")]
        public string imdbID { get; set; }

        [JsonProperty("Type")]
        public string type { get; set; }

        [JsonProperty("Poster")]
        public string poster { get; set; }
    }
}
