using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/elektrikliaracmarketi"),
                Headers =
    {
        { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1 = resultInstagramFollowersDtos.followers;
                ViewBag.v2 = resultInstagramFollowersDtos.following;
  
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-followers.p.rapidapi.com/elonmusk/profile"),
                Headers =
    {
       { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
        { "x-rapidapi-host", "twitter-followers.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.v3 = resultTwitterFollowersDto.followersCount;
                ViewBag.v4 = resultTwitterFollowersDto.friendsCount;
            }

    //        var client3 = new HttpClient();
    //        var request3 = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://twitter-followers.p.rapidapi.com/elonmusk/profile"),
    //            Headers =
    //{
    //   { "x-rapidapi-key", "a44b449bd5mshda46b3818453115p18f680jsn5a4434fb753a" },
    //    { "x-rapidapi-host", "twitter-followers.p.rapidapi.com" },
    //},
    //        };
    //        using (var response3 = await client3.SendAsync(request3))
    //        {
    //            response3.EnsureSuccessStatusCode();
    //            var body3 = await response3.Content.ReadAsStringAsync();
    //            ResultLinkeedinFollowersDto resultLinkeedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkeedinFollowersDto>(body3);
    //            ViewBag.v5 = resultLinkeedinFollowersDto.data.follower_count;
    //            ViewBag.v6 = resultLinkeedinFollowersDto.data.follower_count;
    //        }
            return View();
        }
    }
}
