using ActivityPortal.API.Models;
using ActivityPortal.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portal.Core.Models;
using Portal.Services.Interfaces;

namespace ActivityPortal.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WebsiteInformationController: ControllerBase
    {
        private readonly IWebInformationService _productService;
        private readonly IMapper _mapper;

        public WebsiteInformationController(IWebInformationService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WebsiteInformationResource>> Get()
        {
            var products = _productService.GetAllInformation();
            var productViewModels = _mapper.Map<IEnumerable<WebsiteInformation>, IEnumerable<WebsiteInformationResource>>(products);
            return Ok(productViewModels);
        }



        [HttpGet("{id}")]
        public ActionResult<WebsiteInformationResource> GetById(int id)
        {
            var product = _productService.GetInfoById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<WebsiteInformation, WebsiteInformationResource>(product);
            return Ok(productViewModel);
        }



        [HttpPost]
        public ActionResult<WebsiteInformationResource> Create(WebsiteInformationResource productViewModel)
        {
            var product = _mapper.Map<WebsiteInformationResource, WebsiteInformation>(productViewModel);
            _productService.AddInfo(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, WebsiteInformationResource productViewModel)
        {



            var existingProduct = _productService.GetInfoById(id);


            var product = _mapper.Map<WebsiteInformationResource, WebsiteInformation>(productViewModel);
            _productService.UpdateInfo(product);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetInfoById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteInfo(id);

            return NoContent();
        }
    }
}
