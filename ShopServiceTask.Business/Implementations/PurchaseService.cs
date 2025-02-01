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
    public class PurchaseService : IService<PurchaseDTO>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(PurchaseDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var purchase = _mapper.Map<Purchase>(entity);
                var goods = await _unitOfWork.GoodRepository.GetAll(g => purchase.Items.Select(x => x.GoodId).Contains(g.Id));

                foreach (var item in purchase.Items)
                {
                    var good = goods.FirstOrDefault(g => g.Id == item.GoodId);

                    if (good != null)
                    {
                        purchase.TotalPrice += item.Quantity * good.Price;
                    }
                }

                await _unitOfWork.PurchaseRepository.Create(purchase);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<PurchaseDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PurchaseDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PurchaseDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
