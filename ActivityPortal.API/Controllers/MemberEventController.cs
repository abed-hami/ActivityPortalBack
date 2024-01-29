using ActivityPortal.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Core.Models;
using Portal.Services.Interfaces;

namespace ActivityPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberEventController : ControllerBase
    {
        private readonly IMemberEventService _productService;
        private readonly IMapper _mapper;

        public MemberEventController(IMemberEventService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MembersEventResource>> Get()
        {
            var products = _productService.GetAllMemberEvents();
            var productViewModels = _mapper.Map<IEnumerable<MembersEvent>, IEnumerable<MembersEventResource>>(products);
            return Ok(productViewModels);
        }



        [HttpGet("GetByEmail/{email}")]
        public ActionResult<IEnumerable<dynamic>> GetName(string email)
        {
            var products = _productService.GetName(email);
           
            return Ok(products);
        }



        [HttpGet("GetCount")]
        public ActionResult<int> GetCount()
        {
            var products = _productService.GetCount();

            return Ok(products);
        }


        [HttpGet("{id}")]
        public ActionResult<MembersEventResource> GetById(int id)
        {
            var product = _productService.GetMemberEventById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<MembersEvent, MembersEventResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<MembersEventResource> Create(MembersEventResource productViewModel)
        {
            var product = _mapper.Map<MembersEventResource, MembersEvent>(productViewModel);

            
            string isAddedSuccessfully = _productService.AddMemberEvent(product);

            if (isAddedSuccessfully=="success")
            {
                productViewModel.Id = product.Id;
                return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
            }
            else
            {
                
                return BadRequest("Failed to add member to the event.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MembersEventResource productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productService.GetMemberEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<MembersEventResource, MembersEvent>(productViewModel);
            _productService.UpdateMemberEvent(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetMemberEventById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteMemberEvent(id);

            return NoContent();
        }
    }
}
