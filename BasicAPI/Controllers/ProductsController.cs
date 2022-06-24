using BasicApi.Data;
using BasicApi.Models;
using BasicApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ProductsController(ApiDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = (from v in _context.Products
                            where v.Id == id
                            select new
                            {
                                Id = v.Id,
                                Name = v.ProductName,
                                Description = v.ProductDescription,
                                Keyword = v.KeyWord,
                                DetailContent = v.DetailContent,
                                Content = v.ShortContent

                            }).FirstOrDefault();

            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Product productObj)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                product.ProductName = productObj.ProductName;
                product.ProductDescription = productObj.ProductDescription;
                product.KeyWord = productObj.KeyWord;
                product.ShortContent = product.ShortContent;
                product.DetailContent = productObj.DetailContent;
                _context.SaveChanges();
                return Ok("Record updated successfully");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromForm] ProductDTO product)
        {
            var productObj = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                KeyWord = product.KeyWord,
                ShortContent = product.ShortContent,
                DetailContent = product.DetailContent,
            };

            _context.Products.Add(productObj);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("No record found against this Id");
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Record deleted");
            }
        }
    }
}
