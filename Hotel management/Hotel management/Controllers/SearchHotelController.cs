using Hotel_management.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_management.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class SearchHotelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SearchHotelController(AppDbContext context)
        {

            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("SearchHotel")]
        public async Task<IActionResult> SearchHotel()
        {
            try
            {
                string Term = HttpContext.Request.Query["term"].ToString();
                List<string> Location = await _context.Hotels.Where(h=>h.isDeleted==false && h.Name.Contains(Term)).Select(h=>h.Name).ToListAsync();

                return Ok(Location);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
