using Database;

namespace Services.Catalog.Requests
{
    public class CatalogFilters
    {
        public bool SortByPrice { get; set; } = true;
        public string NameContains { get; set; }
        public decimal? PriceHigherThan { get; set; }
        public decimal? PriceLowerThan { get; set; }
        public string[] Genders { get; set; }
        public string[] Categories { get; set; }
        public string[] Brands { get; set; }
        public ProductColor[] Colors { get; set; }
        public string[] Sizes { get; set; }
    }
}