using Microsoft.AspNetCore.Mvc;
using APW.Data.Repositories;
using APW.Data.Models;
using APW.Models;
namespace APW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ControllerBase
    {

        private readonly ILogger<ProductApiController> _logger;
        private readonly IProductRepository _repository;

        public ProductApiController(ILogger<ProductApiController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<ProductViewModel> Get()
        {
            return _repository.GetAll()
                .Select(p => new ProductViewModel
                {
                    Id = p.ProductId,
                    Name = p.ProductName,
                    Price = p.Rating ?? 0,
                    CategoryId = p.CategoryId ?? 0,
                    CategoryName = p.Category?.CategoryName ?? "Sin categoria"
                })
                .ToList();
        }

    }
}