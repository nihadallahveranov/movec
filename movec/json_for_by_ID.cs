using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class RootObjectForID
    {
        [JsonProperty("Title")]
        public String title { get; set; }

        [JsonProperty("Year")]
        public String year { get; set; }

        [JsonProperty("Rated")]
        public String rated { get; set; }

        [JsonProperty("Released")]
        public String released { get; set; }

        [JsonProperty("Runtime")]
        public String runTime { get; set; }

        [JsonProperty("Genre")]
        public String genre { get; set; }

        [JsonProperty("Director")]
        public String director { get; set; }

        [JsonProperty("Writer")]
        public String writer { get; set; }

        [JsonProperty("Actors")]
        public String actors { get; set; }

        [JsonProperty("Plot")]
        public String plot { get; set; }

        [JsonProperty("Language")]
        public String language { get; set; }

        [JsonProperty("Country")]
        public String country { get; set; }

        [JsonProperty("Awards")]
        public String awards { get; set; }

        [JsonProperty("Poster")]
        public String poster { get; set; }

        [JsonProperty("Ratings")]
        public List<Ratings> ratings { get; set; }

        [JsonProperty("Metascore")]
        public String meteScore { get; set; }

        [JsonProperty("imdbRating")]
        public String imdbRating { get; set; }

        [JsonProperty("imdbVotes")]
        public String imdbVotes { get; set; }

        [JsonProperty("imdbID")]
        public String imdbID { get; set; }

        [JsonProperty("Type")]
        public String type { get; set; }

        [JsonProperty("DVD")]
        public String dvd { get; set; }

        [JsonProperty("BoxOffice")]
        public String boxOffice { get; set; }

        [JsonProperty("Production")]
        public String production { get; set; }

        [JsonProperty("Website")]
        public String webSite { get; set; }

        [JsonProperty("Response")]
        public String response { get; set; }
    }

    class Ratings
    {
        [JsonProperty("Source")]
        public String source { get; set; }

        [JsonProperty("Value")]
        public String value { get; set; }
    }
}
