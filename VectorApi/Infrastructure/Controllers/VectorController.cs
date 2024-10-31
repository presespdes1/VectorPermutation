using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using VectorApi.Domain;
using VectorPermutationTests;

namespace VectorApi.Infrastructure.Controllers
{
    [Route("/vector")]
    [ApiController]
    public class VectorController : ControllerBase
    {
        private readonly IVectorService _vectorService;
        private readonly IMemoryCache _cache;
        private readonly string vectorKey = "vectorCacheKey";

        public VectorController(IVectorService vectorService, IMemoryCache cache)
        {
            _vectorService = vectorService;
            _cache = cache;
        }

        [HttpPost]
        public IActionResult NextPermutation([FromBody] VectorDto vectorDto)
        {

            if (!_cache.TryGetValue(vectorKey, out int[] vector))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);

                vector = _vectorService.NextPermutation(vectorDto.Vector);

                _cache.Set(vectorKey, vector, cacheEntryOptions);
            }

            return Ok(JsonSerializer.Serialize(vector));
        }
    }
}
