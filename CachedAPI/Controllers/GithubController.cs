using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CachedAPI.Controllers
{
    [ApiController]
    [Route("github")]
    public class GithubController : ControllerBase
    {
        public GithubController() { }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            string ApiString;
            using (StreamReader stream = new StreamReader(Request.Body))
            {
                ApiString = await stream.ReadToEndAsync();
            }
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.github.com/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "none");
            HttpResponseMessage response = client.GetAsync(ApiString).Result;

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
