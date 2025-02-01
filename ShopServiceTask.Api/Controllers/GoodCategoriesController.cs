using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopServiceTask.Api.Models.Good;
using ShopServiceTask.Business.DTO;
using ShopServiceTask.Business.Implementations;

namespace ShopServiceTask.Api.Controllers
{
    [ApiController]
    [Route("api/good-categories")]
    public class GoodCategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GoodCategoryService _goodCategorService;

        public GoodCategoriesController(IMapper mapper, GoodCategoryService goodCategoryService)
        {
            _mapper = mapper;
            _goodCategorService = goodCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoodCategory(CreateGoodCategoryModel model)
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
                var goodCategory = _mapper.Map<GoodCategoryDTO>(model);
                await _goodCategorService.Create(goodCategory);

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
