using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Ora_09_Hazi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ora_09_Hazi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products;

        public ProductController()
        {
            products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "A",
                    Price = 100
                },
                new Product
                {
                    Id = 2,
                    Name = "B",
                    Price = 5000
                },
                new Product
                {
                    Id = 3,
                    Name = "C",
                    Price = 4236
                }
            };
        }

        // GET: /Product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        // GET /Product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Product? p = products.FirstOrDefault(x => x.Id == id);

                if (p == null)
                {
                    throw new Exception($"No product exists with this id: {id}");
                }

                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST /Product
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            products.Add(value);
            return Ok();
        }

        // PUT /Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);
            p = value;

            return Ok(p);
        }

        // DELETE /Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);
            products.Remove(p);

            return Ok();
        }
    }
}
