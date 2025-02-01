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
    public class GoodService : IService<GoodDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GoodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(GoodDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var good = _mapper.Map<GoodDTO, Good>(entity);

            await _unitOfWork.GoodRepository.Create(good);
            await _unitOfWork.Save();
        }

        public Task<GoodDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GoodDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GoodDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
