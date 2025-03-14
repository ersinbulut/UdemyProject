using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://imdb-top-1000-movies-series.p.rapidapi.com/byrating"),
                Headers =
    {
        { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
        { "x-rapidapi-host", "imdb-top-1000-movies-series.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "above", "8.1" },
        { "under", "8.2" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
            }
            return View();
        }
    }
}
