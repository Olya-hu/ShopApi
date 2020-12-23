using System.ComponentModel.DataAnnotations;

namespace Services.Catalog.Requests
{
    public class AddItem
    {
        public string VendorCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string[] Sizes { get; set; }
        [Required]
        public short[] Quantities { get; set; }
    }
}