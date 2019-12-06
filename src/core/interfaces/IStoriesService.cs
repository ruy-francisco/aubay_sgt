using core.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.interfaces
{
    public interface IStoriesService
    {
        Task<IEnumerable<StoryDto>> GetBestStories();
    }
}
