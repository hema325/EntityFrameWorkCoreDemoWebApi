using Microsoft.AspNetCore.Mvc;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Controllers
{
    public class CinemaHallsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CinemaHallsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Actor>>> Add(Actor hall)
        {
            await _context.Actors.AddAsync(hall);
            if(await _context.SaveChangesAsync()>0)
               return Ok(_context.Actors);
            
            return BadRequest();
        }
    }
}
