using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.Extensions;

namespace WebApiEntityFramework.Controllers
{
    public class ActorsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> Select(int page, int size)
        {
            var actors = await _context.Actors.OrderBy(a => a.Id).Paginate(page, size).Select(a => new ActorDTO { Id = a.Id, Name = a.Name, DateOfBirth = a.DateOfBirth }).ToListAsync();

            if (actors == null)
                return NotFound();

            return actors;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<int>>> IDs()
        {
            var ids = await _context.Actors.Select(a => a.Id).ToListAsync();

            if (ids == null || ids.Count == 0)
                return NotFound();

            return ids;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> AutoMapper()
        {
            var actors = await _context.Actors.ProjectTo<ActorDTO>(_mapper.ConfigurationProvider).ToListAsync();

            var actor = _mapper.Map<Actor>(actors[0]);

            if (actors == null || actors.Count == 0)
                return NotFound();

            return actors;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Add(ActorDTO actor)
        {
            _context.Add(actor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateUsingConnectedModel(ActorDTO dto)
        {
            var actor = await _context.Actors.FindAsync(dto.Id);

            if (actor == null)
                return NotFound();

            _mapper.Map(dto, actor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateUsingDisConnectedModel(ActorDTO dto)
        {
            if (!await _context.Actors.AnyAsync(a=>a.Id == dto.Id))
                return NotFound();

            var actor = _mapper.Map<Actor>(dto);

            _context.Update(actor);

            //_context.Entry(actor).Property(p => p.Name).IsModified = true; update only property Name

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
