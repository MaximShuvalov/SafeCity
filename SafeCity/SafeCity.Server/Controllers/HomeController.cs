using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using SafeCity.EmailSender;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.Extensions;
using SafeCity.Server.Db.Factory;
using SafeCity.Server.Db.Repositories;
using SafeCity.Server.Db.UnitOfWork;

namespace SafeCity.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class CitizensAppealsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IEmailSenderService _emailSenderService;

        public CitizensAppealsController(AppDbContext context, IUnitOfWork uow, IEmailSenderService emailSenderService)
        {
            _context = context;
            _uow = uow;
            _emailSenderService = emailSenderService;
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

        [HttpGet("allpoints")]
        public async Task<IActionResult> GetAllPoints()
        {
            using (_uow)
                return Ok(await _uow.GetRepositories<GeoPoint>().GetEntities());
        }

        [HttpGet("allbyemail")]
        public async Task<IActionResult> GetAllAppealsByEmail(string email)
        {
            using (_uow)
                return Ok(await ((AppealRepository) _uow.GetRepositories<Appeal>()).GetEntitiesByEmail(email));
        }

        [HttpPost("addappeal")]
        public async Task<IActionResult> AddAppeal([FromBody] Appeal appeal, [FromQuery] string nameSubtype)
        {
            Appeal createdAppeal = null;
            using (_uow)
            {
                await ((AppealRepository) _uow.GetRepositories<Appeal>()).Add(appeal, nameSubtype);
                createdAppeal = ((AppealRepository) _uow.GetRepositories<Appeal>()).Get(appeal);
                _uow.Commit();
            }

            if (createdAppeal != null)
                await SendEmail(createdAppeal);

            return Ok();
        }

        private async Task SendEmail(Appeal appeal)
        {
            var textEmailMessage = $"Спасибо! Ваше обращение{appeal.Key} принято.";
            await _emailSenderService.SendAsync(textEmailMessage, appeal.Email, "Безопасный город");
        }

        [HttpGet("alltypes")]
        public async Task<IActionResult> GetAllTypesAppeal()
        {
            using (_uow)
                return Ok(await _uow.GetRepositories<AppealType>().GetEntities());
        }

        [HttpGet("subtypesbytype")]
        public async Task<IActionResult> GetSubtypeByTypeAppeal(string nameType)
        {
            using (_uow)
                return Ok(await ((SubtypeAppealRepository) _uow.GetRepositories<AppealSubtype>())
                    .GetSubtypeByTypeAppealAsync(nameType));
        }
    }
}