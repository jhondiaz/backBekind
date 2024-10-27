using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testBekind.Application.Ports;
using testBekind.Domain;
using testBekind.Domain.Enum;

namespace testBekindServices.Controllers
{


    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private IProductPort _productPort;

        public ProductController(IProductPort productPort) {
          _productPort = productPort;
        }

        [Authorize(Policy = Permissions.Viewer)]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productPort.GetAllProductsAsync();
        }


        [Authorize(Policy = Permissions.Viewer)]
        [HttpGet]
        public async Task<IEnumerable<string>> GetAllCategory()
        {
            return await _productPort.GetAllCategoryAsync();
        }

        [Authorize(Policy = Permissions.Viewer)]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductByCategory(string name)
        {
            if(name=="All")
                return await _productPort.GetAllProductsAsync();

            return await _productPort.GetProductByCategoryAsync(name);
        }

        [Authorize(Policy = Permissions.Admin)]
        [HttpPost]
        public async Task Add(Product product)
        {
            await _productPort.AddProductAsync(product);
        }

        [Authorize(Policy = Permissions.Admin)]
        [HttpGet()]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productPort.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [Authorize(Policy = Permissions.Admin)]
        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
          
            var success = await _productPort.UpdateProductAsync(product);
            if (!success)
                return NotFound();

            return NoContent();
        }
        [Authorize(Policy = Permissions.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _productPort.DeleteProductAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }


    }



}
