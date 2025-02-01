using AutoMapper;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Interfaces;
using ShopServiceTask.DataAccess.Entities;
using ShopServiceTask.DataAccess.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.Business.Implementations
{
    public class GoodCategoryService : IService<GoodCategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GoodCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(GoodCategoryDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var goodCategory = _mapper.Map<GoodCategory>(entity);
                await _unitOfWork.GoodCategoryRepository.Create(goodCategory);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<GoodCategoryDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GoodCategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GoodCategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
