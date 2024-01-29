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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _productService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleResource>> Get()
        {
            var products = _productService.GetAllRoles();
            var productViewModels = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public ActionResult<RoleResource> GetById(int id)
        {
            var product = _productService.GetRoleById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<Role, RoleResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<RoleResource> Create(RoleResource productViewModel)
        {
            var product = _mapper.Map<RoleResource, Role>(productViewModel);
            _productService.AddRole(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoleResource productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productService.GetRoleById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<RoleResource, Role>(productViewModel);
            _productService.UpdateRole(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetRoleById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteRole(id);

            return NoContent();
        }
    }
}
