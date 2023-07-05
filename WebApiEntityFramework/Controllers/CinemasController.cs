using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.KeyLessEntities;

namespace WebApiEntityFramework.Controllers
{
    public class CinemasController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CinemasController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<CinemaDTO>>> GetAll()
        {
            var cinemas = await _context.Cinemas.ProjectTo<CinemaDTO>(_mapper.ConfigurationProvider).ToListAsync();

            if(cinemas == null || cinemas.Count == 0)
                return NotFound();
            
            return cinemas;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<CinemaWithoutLocation>>> GetAllCinemaWithoutLocations()
        {
            var cinemas = await _context.CinemaWithoutLocations.ToListAsync();

            if (cinemas == null || cinemas.Count == 0)
                return NotFound();

            return cinemas;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetClose(double latitude, double longitude,int maxDistance)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));

            var cinemas = _context.Cinemas.Where(c => c.Location.IsWithinDistance(myLocation, maxDistance))
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Distance = Math.Round(c.Location.Distance(myLocation))
                });

            return Ok(cinemas);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddWithRelated(CinemaDTO dto)
        {
            var cinema = _mapper.Map<Cinema>(dto);

            _context.Add(cinema);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateUsingConnectedModelWithRelated(CinemaDTO dto)
        {
            var cinema = await _context.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.offer)
                .FirstOrDefaultAsync(c=>c.Id == dto.Id);

            if (cinema == null)
                return NotFound();

            _mapper.Map(dto,cinema);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Delete(int id)
        {
            var cinema = await _context.Cinemas
                .Include(c => c.CinemaHalls)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cinema == null)
                return NotFound();

            _context.Remove(cinema);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
