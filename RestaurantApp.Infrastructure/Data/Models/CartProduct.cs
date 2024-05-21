﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Infrastructure.Data.Models
{
	public class CartProduct
	{
		[Required]
        public Guid ShoppingCartId { get; set; }

		[ForeignKey(nameof(ShoppingCartId))]
		public ShoppingCart ShoppingCart { get; set; } = null!;

		[Required]
		public int ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; } = null!;

        public int Quantity { get; set; }	
    }
}
