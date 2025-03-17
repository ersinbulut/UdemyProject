using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cityID)
        {
            if (!string.IsNullOrEmpty(cityID))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?include_adjacency=true&checkout_date=2025-03-27&dest_id={cityID}&units=metric&page_number=0&children_ages=5%2C0&room_number=1&filter_by_currency=EUR&checkin_date=2025-03-24&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=en-gb&children_number=2&order_by=popularity&dest_type=city"),
                    Headers =
    {
        { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?include_adjacency=true&checkout_date=2025-03-27&dest_id=-1456928&units=metric&page_number=0&children_ages=5%2C0&room_number=1&filter_by_currency=EUR&checkin_date=2025-03-24&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=en-gb&children_number=2&order_by=popularity&dest_type=city"),
                    Headers =
    {
        { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
          
        }
    }
}
