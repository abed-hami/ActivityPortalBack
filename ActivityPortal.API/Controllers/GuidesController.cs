using ActivityPortal.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Core.Models;
using Portal.Services.Interfaces;

namespace ActivityPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _productService;
        private readonly IMapper _mapper;

        public GuideController(IGuideService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GuideResource>> Get()
        {
            var products = _productService.GetAllGuides();
            var productViewModels = _mapper.Map<IEnumerable<Guide>, IEnumerable<GuideResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public ActionResult<GuideResource> GetById(int id)
        {
            var product = _productService.GetGuideById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Guide, GuideResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<GuideResource> Create(GuideResource productViewModel)
        {
            var product = _mapper.Map<GuideResource, Guide>(productViewModel);
            _productService.AddGuide(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GuideResource productViewModel)
        {
            

            var existingProduct = _productService.GetGuideById(id);
            

            var product = _mapper.Map<GuideResource, Guide>(productViewModel);
            _productService.UpdateGuide(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetGuideById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteGuide(id);

            return NoContent();
        }
    }
}
