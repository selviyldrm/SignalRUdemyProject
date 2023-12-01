﻿namespace SignalRWebUI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
    }
}