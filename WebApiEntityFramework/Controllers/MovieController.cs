using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.DTOs;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.KeyLessEntities;

namespace WebApiEntityFramework.Controllers
{
    public class MovieController:ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetWithReleated(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Genres.OrderByDescending(g=>g.Name).Where(g => !g.Name.Contains("m")))
                .Include(m=>m.CinemaHalls.OrderByDescending(ch=>ch.Cinema.Name))
                .ThenInclude(ch=>ch.Cinema)
                .Include(m=>m.MovieActors)
                .ThenInclude(ma=>ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var dto = _mapper.Map<MovieDTO>(movie);

            return Ok(dto);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetWithRelatedUsingProjectTo(int id)
        {
            var dto = await _context.Movies.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToListAsync();

            if (dto == null || dto.Count == 0)
                return NotFound();

            return Ok(dto);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> SelectLoading(int id)
        {
            var movie = await _context.Movies.Select(m => new
            {
                Id = m.Id,
                Title = m.Title,
                Genres = m.Genres.Select(g => g.Name).OrderByDescending(n => n).ToList()
            }).ToListAsync();

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> ExplicitLoading(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            var genresCount = await _context.Entry(movie).Collection(m => m.Genres).Query().CountAsync();

            if (movie == null)
                return NotFound();

            return Ok(new
            {
                Id = movie.Id,
                Title = movie.Title,
                GenresCount = genresCount
            });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GroupByInCinemas()
        {
            var movies = _context.Movies.GroupBy(m => m.InCinemas).Select(g => new
            {
                InCinemas = g.Key,
                Count = g.Count(),
                Movies = g.Select(m=>m)
            });

            if (movies == null || movies.Count() == 0)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GroupByGenresCount()
        {
            var movies = _context.Movies.GroupBy(m => m.Genres.Count()).Select(g => new
            {
                Count = g.Key,
                Movies = g.Select(m => m.Title),
                Genres = g.Select(m => m.Genres).SelectMany(g=>g).Distinct()
            });

            if (movies == null || movies.Count() == 0)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Filter([FromQuery]MovieFilterDTO filter)
        {
            var movies = _context.Movies.AsQueryable<Movie>();

            if (!string.IsNullOrEmpty(filter.Title))
                movies = movies.Where(m => m.Title.Contains(filter.Title));

            if (filter.InCinemas)
                movies = movies.Where(m => m.InCinemas == filter.InCinemas);

            if (filter.UpcomingReleases)
                movies = movies.Where(m => m.ReleaseDate > DateTime.Now);

            var dto = _mapper.Map<IEnumerable<MovieDTO>>(await movies.ToListAsync());

            if (dto == null || dto.Count() == 0)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddWithExistingRelated(MovieCreationDTO dto)
        {
            var movie = _mapper.Map<Movie>(dto);

            movie.Genres.ForEach(g => _context.Entry(g).State = EntityState.Unchanged);
            movie.CinemaHalls.ForEach(g => _context.Entry(g).State = EntityState.Unchanged);

            _context.Add(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<MoviesWithCount>> GetMoviesWithCounts()
        {
            return await _context.MoviesWithCounts.ToListAsync();
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<MoviesWithCount> GetMoviesWithCounts(int id)
        {
            return await _context.MoviesWithCounts.FirstOrDefaultAsync(m=>m.Id == id);
        }
    }
}
