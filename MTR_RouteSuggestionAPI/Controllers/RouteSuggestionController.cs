using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTR_RouteSuggestionAPI.Context;
using MTR_RouteSuggestionAPI.Models;

namespace MTR_RouteSuggestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteSuggestionController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public RouteSuggestionController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<RouteSuggestion>> GetAllRouteSuggestions()
        {
            return Ok(await dbContext.RouteSuggestions.ToListAsync());
        }

        [HttpGet("searchRoute")]
        public async Task<ActionResult<IEnumerable<RouteSuggestion>>> GetRouteSuggetion(string startpoint, string endpoint)
        {


            var suggestion = await SearchRoute(startpoint, endpoint);
            if (suggestion.Any())
            {
                return Ok(suggestion);

            }
            return NotFound();

            
        }
        private async Task<IEnumerable<RouteSuggestion>> SearchRoute(string startpoint,string endpoint)
        {
            IQueryable<RouteSuggestion> query = dbContext.RouteSuggestions;
            if ((!string.IsNullOrEmpty(startpoint)) && (!string.IsNullOrEmpty(endpoint))) 
            {
                query=query.Where(e=>e.StartPoint.Equals(startpoint) && e.EndPoint.Equals(endpoint));
            }
            return await query.ToListAsync();

        }

        [HttpPost]
        public async Task<IActionResult> AddRouteSuggestion(RouteSuggestionRequest addRouteSuggestionRequest)
        {
            var routeSuggestion = new RouteSuggestion()
            {
                Id = Guid.NewGuid(),
                StartPoint = addRouteSuggestionRequest.StartPoint,
                EndPoint = addRouteSuggestionRequest.EndPoint,
                TotalNoOfStations = addRouteSuggestionRequest.TotalNoOfStations,
                NoOfStationsInbetween =addRouteSuggestionRequest.NoOfStationsInbetween,
                Fare=addRouteSuggestionRequest.Fare,
                Distance=addRouteSuggestionRequest.Distance
            };
            await dbContext.RouteSuggestions.AddAsync(routeSuggestion);
            await dbContext.SaveChangesAsync();

            return Ok(routeSuggestion);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRouteSuggestion([FromRoute] Guid id, RouteSuggestionRequest updateRouteSuggestionRequest)
        {
            var routeSuggestion = await dbContext.RouteSuggestions.FindAsync(id);

            if (routeSuggestion != null)
            {
                routeSuggestion.StartPoint = updateRouteSuggestionRequest.StartPoint;
                routeSuggestion.EndPoint = updateRouteSuggestionRequest.EndPoint;
                routeSuggestion.TotalNoOfStations = (int)updateRouteSuggestionRequest.TotalNoOfStations;
                routeSuggestion.NoOfStationsInbetween = updateRouteSuggestionRequest.NoOfStationsInbetween;
                routeSuggestion.Fare = updateRouteSuggestionRequest.Fare;
                routeSuggestion.Distance = updateRouteSuggestionRequest.Distance;
                await dbContext.SaveChangesAsync();
                return Ok(routeSuggestion);
            }

            return NotFound();

        }

    }
}
