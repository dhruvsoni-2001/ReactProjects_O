using BoilerPlate.Repository;
using BoilerPlate.Request.Products;
using BoilerPlate.Request.User;
using BoilerPlate.Response.Products;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository _productsRepository)
        {
            productsRepository = _productsRepository;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="start"></param>
        /// <param name="search"></param>
        /// <param name="order_col"></param>
        /// <param name="order_by"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProducts([Required] int limit = 10, [Required] int start = 0, string? search = "", string order_col = "id", string order_by = "Asc")
        {
            var products = productsRepository.GetProducts(limit, start, search, order_col, order_by);
            return Ok(products);
        }

        /// <summary>
        /// To Get Products By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var role = productsRepository.GetProductById(id);
            return Ok(role);
        }

        /// <summary>
        /// For Create a Product
        /// </summary>
        /// <param name="createProductRequest">Represents Products to be Created</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequest createProductRequest)
        {
            var newProduct = productsRepository.CreateProduct(createProductRequest);
            return Ok(newProduct);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id">Represents the Id of Producta to be Updated</param>
        /// <param name="updateProductRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [Required] CreateProductRequest updateProductRequest)
        {
            var updateProduct = productsRepository.UpdateProduct(id, updateProductRequest);
            return Ok(updateProduct);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id">Represents the Id of Products to be Deleted</param> 
        /// <returns> Returns the message of the application.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteProduct(id);
            return Ok(new DeleteProductResponse()
            {
                Status = "Success",
                Message = "Product Deleted Successfully"
            });
        }

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name="id">Represents the Id of Product to be Updated</param>
        /// <param name="updatedStatusRequest">Represents the object of Update Status Request class</param>
        /// <returns>Returns the Update Status Response</returns>
        [HttpPut("status/{id}")]
        public IActionResult UpdateStatus(int id, [Required] UpdatedStatusRequest updatedStatusRequest)
        {
            var status = productsRepository.UpdateStatus(id, updatedStatusRequest);
            return Ok(status);
        }
    }
}
