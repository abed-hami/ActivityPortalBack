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
    public class UserRoleController : ControllerBase
    {
        
            private readonly IUserRoleService _productService;
            private readonly IMapper _mapper;

            public UserRoleController(IUserRoleService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            [HttpGet]
            public ActionResult<IEnumerable<UserRoleResource>> Get()
            {
                var products = _productService.GetAllUserRoles();
                var productViewModels = _mapper.Map<IEnumerable<UsersRole>, IEnumerable<UserRoleResource>>(products);
                return Ok(productViewModels);
            }

            [HttpGet("{id}")]
            public ActionResult<UserRoleResource> GetById(int id)
            {
                var product = _productService.GetUserRoleById(id);
                if (product == null)
                {
                    return NotFound();
                }

                var productViewModel = _mapper.Map<UsersRole, UserRoleResource>(product);
                return Ok(productViewModel);
            }

            [HttpPost]
            public ActionResult<UserRoleResource> Create(UserRoleResource productViewModel)
            {
                var product = _mapper.Map<UserRoleResource, UsersRole>(productViewModel);
                _productService.AddUserRole(product);

                // Update the productViewModel with the generated Id
                productViewModel.Id = product.Id;

                return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, UserRoleResource productViewModel)
            {
                if (id != productViewModel.Id)
                {
                    return BadRequest();
                }

                var existingProduct = _productService.GetUserRoleById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                var product = _mapper.Map<UserRoleResource, UsersRole>(productViewModel);
                _productService.UpdateUserRole(product);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var existingProduct = _productService.GetUserRoleById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                _productService.DeleteUserRole(id);

                return NoContent();
            
        }
    }
}
