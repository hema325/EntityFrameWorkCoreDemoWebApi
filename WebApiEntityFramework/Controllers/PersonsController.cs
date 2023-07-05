using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Data;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Controllers
{
    public class PersonsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<ActionResult<Person>> GetAll(int id)
        {
            var person = await _context.Persons
                .Include(p => p.SendedMessages)
                .Include(p => p.ReceivedMessages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return NotFound();

            return person;
        }
    }
}
