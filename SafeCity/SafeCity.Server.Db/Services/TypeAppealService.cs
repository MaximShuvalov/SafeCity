using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace SafeCity.Server.Db.Services
{
    public class TypeAppealService : ITypeAppealService
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork;

        public TypeAppealService(UnitOfWork.UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppealType> GetAsync(long id) => await Task.Run(() =>
        {
            using(_unitOfWork)
                return _unitOfWork.GetRepositories<AppealType>().Get(id);
        });

        public async Task<IEnumerable<AppealType>> GetAllAsync()
        {
            using(_unitOfWork)
                return await _unitOfWork.GetRepositories<AppealType>().GetEntities();
        }
    }
}