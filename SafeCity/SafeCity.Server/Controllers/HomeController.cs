using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using SafeCity.EmailSender;
using SafeCity.FileStorage.Core;
using SafeCity.Server.Db.Context;
using SafeCity.Server.Db.Extensions;
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
        private readonly IFileStorageService _fileStorageService;

        public CitizensAppealsController(AppDbContext context, IUnitOfWork uow, IEmailSenderService emailSenderService,
            IFileStorageService fileStorageService)
        {
            _context = context;
            _uow = uow;
            _emailSenderService = emailSenderService;
            _fileStorageService = fileStorageService;
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

        // [HttpGet("allpoints")]
        // public async Task<IActionResult> GetAllPoints()
        // {
        //     using (_uow)
        //         return Ok(await _uow.GetRepositories<GeoPoint>().GetEntities());
        // }

        [HttpGet("allbyemail")]
        public async Task<IActionResult> GetAllAppealsByEmail(string email)
        {
            using (_uow)
                return Ok(await ((AppealRepository) _uow.GetRepositories<Appeal>()).GetEntitiesByEmail(email));
        }

        [HttpPost("addappeal")]
        public async Task<IActionResult> AddAppeal([FromBody] Appeal appeal, [FromQuery] string nameSubtype)
        {
            Console.WriteLine($"Подтип '{nameSubtype}'");
            
            if (!string.IsNullOrEmpty(appeal.Attachment))
            {
                var attachmentPath = await _fileStorageService.SaveAttachment(appeal.Attachment);
                appeal.AttachmentPath = attachmentPath;
                appeal.Attachment = String.Empty;
            }

            Appeal createdAppeal = null;
            using (_uow)
            {
                await ((AppealRepository) _uow.GetRepositories<Appeal>()).Add(appeal, nameSubtype);
                createdAppeal = ((AppealRepository) _uow.GetRepositories<Appeal>()).Get(appeal);
                _uow.Commit();
            }

            Console.WriteLine("Обращение создано");

            if (createdAppeal != null)
                await SendEmail(createdAppeal);

            return Ok();
        }
        
        public static bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        
        }

        private async Task SendEmail(Appeal appeal)
        {
            var textEmailMessage = $"Спасибо! Ваше обращение{appeal.Key} принято.";
            await _emailSenderService.SendAsync(textEmailMessage, appeal.Email, "Безопасный город");
        }

        [HttpGet("alltypes")]
        public async Task<IActionResult> GetAllTypesAppeal()
        {
            Console.WriteLine("Принят запрос на получение классов обращений");
            using (_uow)
                return Ok(await _uow.GetRepositories<AppealType>().GetEntities());
        }

        [HttpGet("classbyname")]
        public async Task<IActionResult> GetAllTypesAppeal(string nameClass)
        {
            Console.WriteLine("Принят запрос на получение классов обращений");
            using (_uow)
            {
                var allClasses = await _uow.GetRepositories<AppealType>().GetEntities();
                return Ok(allClasses.FirstOrDefault(p => p.Name.Equals(nameClass)));
            }
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