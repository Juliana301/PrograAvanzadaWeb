using APW.Architecture;
using APW.Models;
using APW.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;


namespace APW.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWrapperServiceProvider _serviceProvider;
        private readonly IRestProvider _restProvider;

        public ProductController(ILogger<ProductController> logger, IWrapperServiceProvider serviceProvider, IRestProvider restProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _restProvider = restProvider;

        }

        public async Task<ActionResult> Index()
        {                                                                   //se debe cambiar para leerse de una configuacion 
            var data = await _serviceProvider.GetDataAsync<IEnumerable<ProductViewModel>>("https://localhost:7006/ProductApi");
            return View(data);
        }

    }
}