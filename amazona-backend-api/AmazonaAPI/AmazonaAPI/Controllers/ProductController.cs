using EFDataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AmazonaAPI.Controllers
{
    [ApiController]
    [Route(template: "products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet(template: "")]
        public IActionResult Index()
        {
            return Ok(_repository.GetProducts());
        }
        [HttpGet(template: "{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_repository.GetProductById(id));
        }
        [HttpGet(template: "product/{slug}")]
        public IActionResult GetProduct(string slug)
        {
            return Ok(_repository.GetProductBySlug(slug));
        }
    }
}
