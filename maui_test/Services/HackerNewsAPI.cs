using maui_test.Models;
using System.Net.Http.Json;

namespace maui_test.Services
{
    public class HackerNewsAPI
    {
        private readonly HttpClient client = new();

        public HackerNewsAPI() { }

        public async Task<List<long>> GetStoryIds()
        {
            var response = await client.GetFromJsonAsync<List<long>>("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty");
            return response ?? new();
        }

        public async Task<HackerNewsStory> GetStorySummery(long id)
        {
            var response = await client.GetFromJsonAsync<HackerNewsStory>($"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty");
            return response ?? new();
        }

        public async Task<string> GetArtical(long id)
        {
            return ""; // If not possible to re-direct the user to the artical
        }
    }
}
