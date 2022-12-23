using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTR_RouteSuggestionAPI.Context;
using MTR_RouteSuggestionAPI.Models;

namespace MTR_RouteSuggestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public StationController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Station>> GetAllStations()
        {
            return Ok(await dbContext.Stations.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStation([FromRoute] Guid id)
        {
            var station = await dbContext.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station); ;

        }

        [HttpPost]
        public async Task<IActionResult> AddStation(StationRequest addStationRequest)
        {
            var station = new Station()
            {
                Id = Guid.NewGuid(),
                Name = addStationRequest.Name,
                Description = addStationRequest.Description
            };
            await dbContext.Stations.AddAsync(station);
            await dbContext.SaveChangesAsync();

            return Ok(station);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStation([FromRoute] Guid id, StationRequest updateStationRequest)
        {
            var station = await dbContext.Stations.FindAsync(id);

            if (station != null)
            {
                station.Name = updateStationRequest.Name;
                station.Description = updateStationRequest.Description;
                await dbContext.SaveChangesAsync();
                return Ok(station);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStation([FromRoute] Guid id)
        {
            var station = await dbContext.Stations.FindAsync(id);
            if (station != null)
            {
                dbContext.Remove(station);
                await dbContext.SaveChangesAsync();
                return Ok(station);
            }

            return NotFound();

        }
    }
}
