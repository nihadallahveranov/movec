using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class MovieAPI
    {
        public async Task<RootObjectForBySearch> getImdbIDAsync(String movieName, String page)
        {
		try
            	{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://movie-database-alternative.p.rapidapi.com/?s=" + movieName + "&r=json&page=" + page),
				Headers =
				{
					{ "X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com" },
					{ "X-RapidAPI-Key", HideInformation.kRapidAPIKey },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<RootObjectForBySearch>(body);
                	}
		}

            	catch (Exception)
            	{
			return JsonConvert.DeserializeObject<RootObjectForBySearch>("");
		}
	}

	public async Task<RootObjectForID> getAllInfosAsync(String imdbID)
        {
		try
            	{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://movie-database-alternative.p.rapidapi.com/?r=json&i=" + imdbID + "&plot=full"),
				Headers =
				{
					{ "X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com" },
					{ "X-RapidAPI-Key", HideInformation.kRapidAPIKey },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
                    		return JsonConvert.DeserializeObject<RootObjectForID>(body);
			}
		}
            	catch (Exception)
            	{
			return JsonConvert.DeserializeObject<RootObjectForID>("");
		}
	}

	public async Task<RootObjectForTrailerData> getTrailerDataAsync(String imdbID)
        {
		try
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-api.com/en/API/Trailer/" + HideInformation.kIMBDAPIKey + "/" + imdbID),
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
                    		return JsonConvert.DeserializeObject<RootObjectForTrailerData>(body);
			}
		}

		catch (Exception)
		{
			return JsonConvert.DeserializeObject<RootObjectForTrailerData>("");
		}
	}
    }
}
