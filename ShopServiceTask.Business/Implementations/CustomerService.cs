using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Interfaces;
using ShopServiceTask.Common.Exceptions;
using ShopServiceTask.DataAccess.Entities;
using ShopServiceTask.DataAccess.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServiceTask.Business.Implementations
{
    public class CustomerService : IService<CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var mappedCustomer = _mapper.Map<Customer>(customerDTO);
                await _unitOfWork.CustomerRepository.Create(mappedCustomer);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<CustomerDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDTO>> GetBirthdayPersons(DateOnly date)
        {
            try
            {
                var customers = await _unitOfWork.CustomerRepository.GetAll(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day);
                var mappedCustomers = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

                return mappedCustomers;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IEnumerable<CustomerDTO>> GetRecentCustomers(int days)
        {
            try
            {
                var lowerDateBoundary = DateTime.UtcNow.AddDays(-days);

                var recentCustomers = await _unitOfWork.CustomerRepository.GetAll(c => c.Purchases.Any(p => p.PurchaseDate >= lowerDateBoundary), includeProperties: q => q.Include(c => c.Purchases));
                var recentCustomersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(recentCustomers);

                return recentCustomersDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PopularGoodCategoryDTO>> GetPopularCategories(int customerId)
        {
            try
            {
                var customer = await _unitOfWork.CustomerRepository.Get(customerId);

                if (customer == null)
                {
                    throw new CustomerNotFoundException("Customer doesn't exist");
                }

                var purchases = await _unitOfWork.PurchaseRepository.GetAll(p => p.CustomerId == customer.Id,
                    includeProperties: q => q.Include(p => p.Items).ThenInclude(i => i.Good).ThenInclude(g => g.Category));

                var categories = purchases.SelectMany(p => p.Items)
                    .GroupBy(i => i.Good.CategoryId)
                    .Select(g => new PopularGoodCategoryDTO
                    {
                        Id = g.Key,
                        Name = g.First().Good.Category.Name,
                        GoodsCount = g.Sum(i => i.Quantity)
                    })
                    .OrderByDescending(c => c.GoodsCount).ToList();

                return categories;
            }
            catch (CustomerNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Remove(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.Get(id);

            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer doesn't exist");
            }

            _unitOfWork.CustomerRepository.Delete(customer);
            await _unitOfWork.Save();
        }

        public Task Update(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
