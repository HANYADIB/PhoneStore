﻿using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Product Products { get; set; }
        public ShoppingCart ShoppingCarts { get; set; }
    }
}
