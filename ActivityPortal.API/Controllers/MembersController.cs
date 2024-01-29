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
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _productService;
        private readonly IMapper _mapper;

        public MemberController(IMemberService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemberResource>> Get()
        {
            var products = _productService.GetAllMembers();
            var productViewModels = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public ActionResult<MemberResource> GetById(int id)
        {
            var product = _productService.GetMemberById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Member, MemberResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<MemberResource> Create(MemberResource productViewModel)
        {
            var email = _productService.GetMemberByUsername(productViewModel.Email);
            if(email == null)
            {
                var product = _mapper.Map<MemberResource, Member>(productViewModel);
                _productService.AddMember(product);

                // Update the productViewModel with the generated Id
                productViewModel.Id = product.Id;

                return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MemberResource productViewModel)
        {
           

            var existingProduct = _productService.GetMemberById(id);
            
            var product = _mapper.Map<MemberResource, Member>(productViewModel);
            _productService.UpdateMember(product);

            return NoContent();
        }

        [HttpGet("GetByEmail/{email}/{pass}")]
        public ActionResult<MemberResource> GetByEmail(string email, string pass)
        {
            var product = _productService.GetMemberByEmail(email, pass);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Member, MemberResource>(product);
            return Ok(productViewModel);
        }

        [HttpGet("GetByUsername/{email}")]
        public ActionResult<MemberResource> GetByUsername(string email)
        {
            var product = _productService.GetMemberByUsername(email);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Member, MemberResource>(product);
            return Ok(productViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetMemberById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteMember(id);

            return NoContent();
        }
    }
}
