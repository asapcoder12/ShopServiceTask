using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopServiceTask.Api.Models.Purchase;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Implementations;

namespace ShopServiceTask.Api.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchasesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PurchaseService _purchaseService;

        public PurchasesController(IMapper mapper, PurchaseService purchaseService)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var purchase = _mapper.Map<CreatePurchaseModel, PurchaseDTO>(model);

                await _purchaseService.Create(purchase);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
