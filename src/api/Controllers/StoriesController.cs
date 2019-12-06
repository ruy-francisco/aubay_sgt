using core.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : Controller
    {
        private readonly IStoriesService _storiesService;

        public StoriesController(IStoriesService storiesService)
        {
            _storiesService = storiesService;
        }

        [HttpGet("GetBestStories")]
        public async Task<IActionResult> GetBestStories()
        {
            try
            {
                var stories = await _storiesService.GetBestStories();
                return Ok(stories);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
