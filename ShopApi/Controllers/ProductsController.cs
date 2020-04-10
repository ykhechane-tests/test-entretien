using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopApi.Models;
using System;
using System.Linq;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/V1")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDBContext _shopDBContext;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ShopDBContext shopDBContext, ILogger<ProductsController> logger)
        {
            _shopDBContext = shopDBContext;
            _logger = logger;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts()
        {
            var products = _shopDBContext.Product.ToList();

            if (!products.Any())
            {
                return NoContent();
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("products/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _shopDBContext.Product.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        [Route("products")]
        public IActionResult AddProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _shopDBContext.Product.Add(product);

                _shopDBContext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception e)
            {
                _logger.LogCritical("Error on add product", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("products")]
        public IActionResult UpdateProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _shopDBContext.Product.Update(product);

                _shopDBContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception e)
            {
                _logger.LogCritical("Error on add product", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _shopDBContext.Product.Remove(new Product
                {
                    Id = id
                });

                _shopDBContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception e)
            {
                _logger.LogCritical("Error on delete product", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("oreders")]
        public IActionResult GetPurchases()
        {
            try
            {
                var orders = _shopDBContext.Customer.
                    Include(a=>a.Order).                    
                    Select(c => new
                {
                    c.Email,
                    Total = c.Order.SelectMany(a => a.OrderItem.Select(a => a.Product.Price)).Sum()
                });

                if (!orders.Any())
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Error on delete product", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
