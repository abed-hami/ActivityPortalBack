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
    public class UserController : ControllerBase
    {
        private readonly IUserService _productService;
        private readonly IMapper _mapper;

        public UserController(IUserService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResource>> Get()
        {
            var products = _productService.GetAllUsers();
            var productViewModels = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<UserResource> GetById(int id)
        {
            var product = _productService.GetUserById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<User, UserResource>(product);
            return Ok(productViewModel);
        }

        [HttpGet("GetByEmail/{email}/{pass}")]
        public ActionResult<UserResource> GetByEmail(string email, string pass)
        {
            var product = _productService.GetUserByEmail(email, pass);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<User, UserResource>(product);
            return Ok(productViewModel);
        }

        [HttpGet("GetByUsername/{email}")]
        public ActionResult<UserResource> GetByUsername(string email)
        {
            var product = _productService.GetUserByUsername(email);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<User, UserResource>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public ActionResult<UserResource> Create(UserResource productViewModel)
        {
            var product = _mapper.Map<UserResource, User>(productViewModel);
            _productService.AddUser(product);

            // Update the productViewModel with the generated Id
            productViewModel.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserResource productViewModel)
        {
            

            var existingProduct = _productService.GetUserById(id);
            

            var product = _mapper.Map<UserResource, User>(productViewModel);
            _productService.UpdateUser(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetUserById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.DeleteUser(id);

            return NoContent();
        }
    }
}
