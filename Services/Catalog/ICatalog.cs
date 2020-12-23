using System.Collections.Generic;
using System.Threading.Tasks;
using Database;

namespace Services.Catalog
{
    public interface ICatalog
    {
        Task<List<Product>> GetWithFilters(CatalogFilters filters);
        Task AddProduct(Requests.AddItem request);
    }
}