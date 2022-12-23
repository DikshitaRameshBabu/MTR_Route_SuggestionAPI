using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTR_RouteSuggestionAPI.Context;
using MTR_RouteSuggestionAPI.Models;

namespace MTR_RouteSuggestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public SearchHistoryController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> searchHistory([FromBody] SearchHistory search)
        {
            if (search == null)
                return BadRequest();

           
            await dbContext.SearchHistories.AddAsync(search);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Search History stored !" });

        }

        [HttpGet]
        public async Task<ActionResult<SearchHistory>> GetSearchHistory()
        {
            return Ok(await dbContext.SearchHistories.ToListAsync());
        }
    }
}
