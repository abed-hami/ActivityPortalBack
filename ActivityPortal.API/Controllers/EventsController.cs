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
    public class EventsController : ControllerBase
    {
        private readonly IEventService _productService;
        private readonly IMapper _mapper;

        public EventsController(IEventService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventResource>> Get()
        {
            var products = _productService.GetAllEvents();
            var productViewModels = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(products);
            return Ok(productViewModels);
        }

    

        [HttpGet("{id}")]
        public ActionResult<EventResource> GetById(int id)
        {
            var product = _productService.GetEventById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Event, EventResource>(product);
            return Ok(productViewModel);
        }

        

        [HttpPost]
        public ActionResult<EventResource> Create(EventResource productViewModel)
        {
            var product = _mapper.Map<EventResource, Event>(productViewModel);
            _productService.AddEvent(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EventResource productViewModel)
        {
            
            

            var existingProduct = _productService.GetEventById(id);
            

            var product = _mapper.Map<EventResource, Event>(productViewModel);
            _productService.UpdateEvent(product);

            return NoContent();
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteEvent(id);

            return NoContent();
        }
    }
}
