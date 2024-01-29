using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Core.Models;
using AutoMapper;
using Portal.Services.Interfaces;
using ActivityPortal.API.Resources;

namespace ActivityPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuideEventController : ControllerBase
    {
        private readonly IGuideEventService _productService;
        private readonly IMapper _mapper;

        public GuideEventController(IGuideEventService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GuidesEventResource>> Get()
        {
            var products = _productService.GetAllGuideEvents();
            var productViewModels = _mapper.Map<IEnumerable<GuidesEvent>, IEnumerable<GuidesEventResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("GetAssignedGuides")]
        public ActionResult<IEnumerable<dynamic>> GetAssignedGuides()
        {
            var products = _productService.GetAssignedGuides();
           
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<GuidesEventResource> GetById(int id)
        {
            var product = _productService.GetGuideEventById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<GuidesEvent, GuidesEventResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<GuidesEventResource> Create(GuidesEventResource productViewModel)
        {
            var product = _mapper.Map<GuidesEventResource, GuidesEvent>(productViewModel);
            var exist= _productService.AddGuideEvent(product);

            if (exist == "success")
            {
             productViewModel.Id = product.Id;

                        return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
            }
            return BadRequest("guide already assigned!");
           
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GuidesEventResource productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productService.GetGuideEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<GuidesEventResource, GuidesEvent>(productViewModel);
            _productService.UpdateGuideEvent(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetGuideEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteGuideEvent(id);

            return NoContent();
        }
    }
}
