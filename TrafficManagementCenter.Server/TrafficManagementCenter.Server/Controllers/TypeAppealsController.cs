using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Repositories;

namespace TrafficManagementCenter.Server.Controllers
{
    [Route("api/typeappeals")]
    [ApiController]
    public class TypeAppealsController: ControllerBase
    {
        private AppDbContext _context;

        public TypeAppealsController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("ping")]
        public int Ping()
        {
            return StatusCodes.Status200OK;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTypeAppeal()
        {
            var repos = new TypeAppealRepository(_context); 
            var typesAppeal = await repos.GetEntities();
            return Ok(typesAppeal);
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddTypeAppeal(TypeAppeal typeAppeal)
        {
            var repos = new TypeAppealRepository(_context); 
             await repos.Add(typeAppeal);
            return Ok();
        }
    }
}