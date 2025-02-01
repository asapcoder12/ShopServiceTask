using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopServiceTask.Api.Models.Customer;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Implementations;
using ShopServiceTask.Common.Exceptions;

namespace ShopServiceTask.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CustomerService _customerService;
        public CustomersController(IMapper mapper, CustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet("birthday-persons")]
        public async Task<IActionResult> GetBirthdayPersons([FromQuery]DateOnly date)
        {
            try
            {
                var customers = await _customerService.GetBirthdayPersons(date);
                var mappedCustomers = _mapper.Map<IEnumerable<BirthdayPersonModel>>(customers);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentCustomers([FromQuery]int days)
        {
            try
            {
                var recentCustomers = await _customerService.GetRecentCustomers(days);
                var mappedRecentCustomers = _mapper.Map<IEnumerable<RecentCustomerModel>>(recentCustomers);

                return Ok(mappedRecentCustomers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{customerId}/popular-categories")]
        public async Task<IActionResult> GetPopularCategories([FromRoute] int customerId)
        {
            try
            {
                var categories = await _customerService.GetPopularCategories(customerId);
                var mappedCategories = _mapper.Map<IEnumerable<PopularGoodCategoryModel>>(categories);

                return Ok(categories);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerModel model)
        {
            if (model == null)
            {
                return BadRequest("No data provided");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = _mapper.Map<CustomerDTO>(model);

                await _customerService.Create(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                await _customerService.Remove(customerId);

                return NoContent();
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
