using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog;
using Services.Catalog.Requests;

namespace ShopApi.Controllers
{
    [Route("catalog")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalog _catalog;

        public CatalogController(ICatalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public async Task<List<Product>> Index([FromQuery] CatalogFilters filters)
        {
            return await _catalog.GetWithFilters(filters);
        }

        [HttpPost]
        [Route("addItem")]
        public async void AddItem([FromBody] AddItem request)
        {
            await _catalog.AddProduct(request);
        }
    }
}
