using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomifyAR.Entities;
using RoomifyAR.Errors;
using RoomifyAR.Repositories;
using RoomifyAR.Requests;
using RoomifyAR.Specifications;

namespace RoomifyAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepo repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] ProductSpec spec)
        {
            return Ok(await repo.GetProductsWithSpec(spec));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await repo.GetProductById(Id));
        }

        [HttpGet("new-arrival")]
        public async Task<ActionResult<IEnumerable<Product>>> GetNewArrival()
        {
            return Ok(await repo.GetNewArrival());
        }

        [HttpGet("best-seller")]
        public async Task<ActionResult<IEnumerable<Product>>> GetBestSeller()
        {
            return Ok(await repo.GetBestSeller());
        }

        [HttpGet("category/{cateId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(int cateId)
        {
            return Ok(await repo.GetByCategory(cateId));
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await repo.GetCategories());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product request)
        {
            return Ok(await repo.Add(request));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut()]
        public async Task<ActionResult> Update(Product product)
        {
            await repo.Update(product);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await repo.Delete(Id);
            return Ok();
        }

        [HttpPost("add-task-create-model")]
        public async Task<ActionResult> AddTaskCreate3DModel(TaskCreateModelRequest request)
        {
            try
            {
                if (request.Images.Count == 0)
                {
                    return BadRequest("No image found!");
                }

                await repo.AddTaskCreate3DModel(request.Images[0], request.ProductId);
                return Ok("Add task successfully! The creation is in progress.");
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-model")]
        public async Task<ActionResult> Get3DModel(int productId)
        {
            try
            {
                return Ok(await repo.Get3DModel(productId));
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("remove-model")]
        public async Task<ActionResult> Remove3DModel(int productId)
        {
            try
            {
                await repo.Delete3DModel(productId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
