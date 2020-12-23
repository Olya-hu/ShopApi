﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Orders.Requests
{
    public class OrderRequest
    {
        [Required]
        public int ShippingId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int[] ProductIds { get; set; }
    }
}
