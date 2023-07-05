using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.Extensions;

namespace WebApiEntityFramework.Controllers
{
    public class GenresController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.AsNoTracking().ToListAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<Genre> First()
        {
            return await _context.Genres.FirstAsync(g => g.Name.Contains("hema"));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Genre>> FirstOrDefault()
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name.Contains("hema"));

            if (genre == null)
                return NotFound();

            return genre;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Genre>>> Where(string filter)
        {
            var genres = await _context.Genres.Where(g => g.Name.StartsWith(filter)).ToListAsync();

            if (genres == null || genres.Count == 0)
                return NotFound();

            return genres;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Genre>>> Pagination(int page,int size)
        {
            var genres = await _context.Genres.Paginate(page,size).ToListAsync();

            if (genres == null || genres.Count == 0)
                return NotFound();

            return genres;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<object>> Select()
        {
            var genres =  await _context.Genres.Select(g => new { id = g.Id,name = g.Name }).ToListAsync();

            if (genres == null || genres.Count == 0)
                return NotFound();

            return genres;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Add(GenreDTO dto)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            if (await _context.Genres.AnyAsync(g => g.Name == dto.Name))
                return BadRequest("Genre Name Is Already Existed");

            var genre = _mapper.Map<Genre>(dto);
            var state1 = _context.Entry(genre).State;

            _context.Add(genre);
            var state2 = _context.Entry(genre).State;

            await _context.SaveChangesAsync();
            var state3 = _context.Entry(genre).State;

            await transaction.RollbackAsync();

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddMultiple(IEnumerable<GenreDTO> dtos)
        {
            var genres = _mapper.Map<IEnumerable<Genre>>(dtos);

            //foreach (var genre in genres)
            //    _context.Add(genre);

            _context.AddRange(genres); //same as above
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
                return NotFound();

            _context.Remove(genre); 
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null || genre.IsDeleted)
                return NotFound();

            genre.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Genre>> GetSoftDeleted()
        {
            return await _context.Genres.IgnoreQueryFilters().Where(g=>g.IsDeleted).ToListAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Genre>> GetUsingSqlRaw(int id)
        {
            return await _context.Genres.FromSqlRaw("select * from genres where Id = {0}",id).Include(g=>g.Movies).ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<Genre> GetUsingSqlInterpolated(int id)
        {  
            return await _context.Genres.FromSqlInterpolated($"select * from genres where Id = {id}").Include(g => g.Movies).FirstOrDefaultAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ExecuteSqlInterpolated(string name)
        {
           await _context.Database.ExecuteSqlInterpolatedAsync($"insert into genres(name) values ({name})");

           return Ok();
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<IEnumerable<Genre>> StoredProcedure(int id)
        {
            return await _context.Genres.FromSqlInterpolated($"Exec Genres_Get {id}").IgnoreQueryFilters().ToListAsync();
        }
    }
}
