using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopServiceTask.Api.Models.Good;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Implementations;

namespace ShopServiceTask.Api.Controllers
{
    [ApiController]
    [Route("api/goods")]
    public class GoodsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GoodService _goodService;

        public GoodsController(IMapper mapper, GoodService goodService)
        {
            _mapper = mapper;
            _goodService = goodService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGood(CreateGoodModel model)
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
                var good = _mapper.Map<GoodDTO>(model);
                await _goodService.Create(good);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
