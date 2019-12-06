using core.domain;
using core.interfaces;
using core.model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace core.services
{
    public class StoriesService : IStoriesService
    {
        private readonly IStoriesIntegration _storiesIntegration;

        public StoriesService(IStoriesIntegration storiesIntegration)
        {
            _storiesIntegration = storiesIntegration;
        }

        public async Task<IEnumerable<StoryDto>> GetBestStories()
        {
            var listOfDomainStories = new List<Story>();
            long currentId = 0;
            Story retrievedStory = null;

            var bestStoriesIds = await _storiesIntegration.GetBestStoriesIds();
            var storiesIdsEnumerator = bestStoriesIds.GetEnumerator();

            while (storiesIdsEnumerator.MoveNext())
            {
                currentId = storiesIdsEnumerator.Current;
                retrievedStory = await _storiesIntegration.GetStoryById(currentId);

                listOfDomainStories.Add(retrievedStory);
            }

            var orderedListOfDomainStories = listOfDomainStories.OrderByDescending(s => s.score);
            var best20Stories = orderedListOfDomainStories.Take(20);

            var listOfStoriesDto = StoryDto.Create(best20Stories);

            return listOfStoriesDto;
        }
    }
}
