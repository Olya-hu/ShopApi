﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    [Table("product")]
    public partial class Product
    {
        public Product()
        {
            ProductOrder = new HashSet<ProductOrder>();
            ProductSize = new HashSet<ProductSize>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("vendor_code", TypeName = "varchar(16)")]
        public string VendorCode { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(16)")]
        public string Name { get; set; }
        [Required]
        [Column("price", TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Column("description", TypeName = "mediumtext")]
        public string Description { get; set; }
        [Required]
        [Column("gender", TypeName = "enum('Male','Female','Unisex')")]
        public string Gender { get; set; }
        [Required]
        [Column("category", TypeName = "enum('Clothes','Footwear','Accessories','Sportswear')")]
        public string Category { get; set; }
        [Required]
        [Column("brand", TypeName = "enum('Adidas','Nike','Puma','Supreme')")]
        public string Brand { get; set; }
        [Required]
        [Column("color", TypeName = "enum('White','Black','Black&White','Grey','Red','Orange','Yellow','Green','Cyan','Blue','Purple','Pink','Multicolor')")]
        public string Color { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductSize> ProductSize { get; set; }
    }
}
