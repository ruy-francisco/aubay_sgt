using core.domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.interfaces
{
    public interface IStoriesIntegration
    {
        Task<IEnumerable<long>> GetBestStoriesIds();
        Task<Story> GetStoryById(long id);
    }
}
