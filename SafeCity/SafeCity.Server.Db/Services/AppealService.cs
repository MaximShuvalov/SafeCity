using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public class AppealService : IAppealService
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork;
        private readonly ISubtypeAppealService _subtypeAppealService;

        public AppealService(UnitOfWork.UnitOfWork unitOfWork, ISubtypeAppealService subtypeAppealService)
        {
            _unitOfWork = unitOfWork;
            _subtypeAppealService = subtypeAppealService;
        }

        public async Task<IEnumerable<Appeal>> GetAllAsync()
        {
            using (_unitOfWork)
                return await _unitOfWork.GetRepositories<Appeal>().GetEntities();
        }

        public async Task<Appeal> Add(Appeal appeal, string nameSubtypeAppeal)
        {
            using (_unitOfWork)
            {
                var subtypeAppeals = await _subtypeAppealService.GetAllAsync();

                var subtypeAppeal = subtypeAppeals.FirstOrDefault(p => p.Name.Equals(nameSubtypeAppeal));
                
                if (subtypeAppeal is null)
                    throw new Exception("The database does not contain the given object");
                
                appeal.SubtypeId = subtypeAppeal.Key;
                appeal.AppealTypeId = subtypeAppeal.TypesId;
                appeal.IsResolve = false;

                await _unitOfWork.GetRepositories<Appeal>().Add(appeal);
                
                _unitOfWork.Commit();
                
                return (await GetAllAsync()).FirstOrDefault(p => p.Text.Equals(appeal.Text) && p.Email.Equals(appeal.Email));
            }
        }
    }
}