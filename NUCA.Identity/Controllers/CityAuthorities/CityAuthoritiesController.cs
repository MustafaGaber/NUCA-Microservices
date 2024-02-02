using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Controllers.Core;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NUCA.Identity.Controllers.CityAuthorities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAuthoritiesController : BaseController
    {
        private ApplicationDbContext _context;
        public CityAuthoritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = User;
            var cities = await _context.CityAuthorities
                           .Select(c => new { c.Id, c.Name })
                           .ToListAsync();
            return Ok(cities);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CityAuthorityModel model)
        {
            CityAuthority city = new CityAuthority(model.Name);
            _context.CityAuthorities.Add(city);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityAuthorityModel model)
        {
            var city = await _context.CityAuthorities.FirstOrDefaultAsync(d => d.Id == id) ?? throw new InvalidOperationException();
            city.Update(model.Name);
            _context.CityAuthorities.Update(city);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
