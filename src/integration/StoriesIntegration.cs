using core.domain;
using core.interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace integration
{
    public class StoriesIntegration : IStoriesIntegration
    {
        private readonly HttpClient _httpClient;

        public StoriesIntegration(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<long>> GetBestStoriesIds()
        {
            var stringResponse = await _httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json");
            var retrievedIds = JsonConvert.DeserializeObject<IEnumerable<long>>(stringResponse);
            return retrievedIds;
        }

        public async Task<Story> GetStoryById(long id)
        {
            var stringResponse = await _httpClient.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{id}.json");
            var retrievedStory = JsonConvert.DeserializeObject<Story>(stringResponse);
            return retrievedStory;
        }
    }
}
