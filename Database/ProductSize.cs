﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    [Table("product_size")]
    public partial class ProductSize
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Key]
        [Column("size", TypeName = "enum('36','38','40','42','44','46','48','50','52','54','56')")]
        public string Size { get; set; }
        [Column("quantity")]
        public short Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductSize")]
        public virtual Product Product { get; set; }
    }
}
