﻿namespace Altkom.Shop.Models
{
    public class Product : Item
    {
        public string Color { get; set; }
        public float Weight { get; set; }
        public byte[] Photo { get; set; }
    }
}
