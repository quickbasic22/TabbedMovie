using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QuickType1;

namespace TabbedMovie.Services
{
    public class GetMovies
    {
        public async Task<List<QuickType1.MovieResult>> GetMovieList(string title)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(@"https://movies-tvshows-data-imdb.p.rapidapi.com/?type=get-movies-by-title&title=" + title),
                Headers =
            {
                { "x-rapidapi-host", "movies-tvshows-data-imdb.p.rapidapi.com" },
                { "x-rapidapi-key", "b102e5ccb7mshb4ec275675dc83cp1938d1jsnd2017acb869e" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var movieInfo = MovieInfo.FromJson(body);
                return movieInfo.MovieResults.ToList();
            }
        }
    }
}
