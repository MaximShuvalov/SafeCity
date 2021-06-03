using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using TrafficManagementCenter.Server.Db.Context;
using TrafficManagementCenter.Server.Db.Extensions;
using TrafficManagementCenter.Server.Db.Factory;
using TrafficManagementCenter.Server.Db.Repositories;
using TrafficManagementCenter.Server.Db.UnitOfWork;

namespace TrafficManagementCenter.Server.Controllers
{
    [Route("api/citizens")]
    [ApiController]
    public class CitizensAppealsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _uow;

        public CitizensAppealsController(AppDbContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        [HttpGet("ping")]
        public int Ping()
        {
            return StatusCodes.Status200OK;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAppeal()
        {
            using (_uow)
                return Ok(await _uow.GetRepositories<Appeal>().GetEntities());
        }

        [HttpGet("allbyemail")]
        public async Task<IActionResult> GetAllAppealsByEmail(string email)
        {
            using (_uow)
                return Ok(await ((AppealRepository) _uow.GetRepositories<Appeal>()).GetEntitiesByEmail(email));
        }

        [HttpPost("addappeal")]
        public async Task<IActionResult> AddAppeal([FromBody] Appeal appeal, [FromQuery] string nameClass,
            [FromQuery] string nameSubtype)
        {
            //todo mshuvalov: подумать на передачей контекста
            using (_uow)
            {
                await ((AppealRepository) _uow.GetRepositories<Appeal>()).Add(appeal, nameClass, nameSubtype);
                _uow.Commit();
            }

            return Ok();
        }

        [HttpGet("alltypes")]
        public async Task<IActionResult> GetAllTypesAppeal()
        {
            using(_uow)
                return Ok(await _uow.GetRepositories<TypeAppeal>().GetEntities());
        }

        [HttpGet("allclasses")]
        public async Task<IActionResult> GetAllClassesAppeal()
        {
            using(_uow)
                return Ok(await _uow.GetRepositories<AppealClass>().GetEntities());
        }

        [HttpGet("subtypesbytype")]
        public async Task<IActionResult> GetSubtypeByTypeAppeal(string nameType)
        {
            using(_uow)
                return Ok( await ((SubtypeAppealRepository) _uow.GetRepositories<SubtypeAppeal>()).GetSubtypeByTypeAppealAsync(nameType));
        }
    }
}