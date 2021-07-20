using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public class SubtypeAppealService : ISubtypeAppealService
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork;
        private readonly TypeAppealService _typeAppealService;

        public SubtypeAppealService(UnitOfWork.UnitOfWork unitOfWork, TypeAppealService typeAppealService)
        {
            _unitOfWork = unitOfWork;
            _typeAppealService = typeAppealService;
        }

        public async Task<IEnumerable<AppealSubtype>> GetAllAsync()
        {
            using (_unitOfWork)
                return await _unitOfWork.GetRepositories<AppealSubtype>().GetEntities();
        }

        public async Task<IEnumerable<AppealSubtype>> GetSubtypeByTypeAppealAsync(string nameTypeAppeal)
        {
            using (_unitOfWork)
            {
                var keyType = ( await _typeAppealService.GetAllAsync())
                    .FirstOrDefault(p => p.Name.Equals(nameTypeAppeal))?.Key;
                return (await GetAllAsync()).Where(x => x.TypesId.Equals(keyType));
            }
        }
    }
}