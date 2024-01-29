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
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _productService;
        private readonly IMapper _mapper;

        public LookupController(ILookupService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LookupResource>> Get()
        {
            var products = _productService.GetAllLookups();
            var productViewModels = _mapper.Map<IEnumerable<Lookup>, IEnumerable<LookupResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public ActionResult<LookupResource> GetById(int id)
        {
            var product = _productService.GetLookupById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Lookup, LookupResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<LookupResource> Create(LookupResource productViewModel)
        {
            var product = _mapper.Map<LookupResource, Lookup>(productViewModel);
            _productService.AddLookup(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LookupResource productViewModel)
        {
           

            var existingProduct = _productService.GetLookupById(id);
            
            var product = _mapper.Map<LookupResource, Lookup>(productViewModel);
            _productService.UpdateLookup(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetLookupById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteLookup(id);

            return NoContent();
        }
    }
}
