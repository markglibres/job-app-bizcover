﻿namespace BizCover.Api.Cars.Dtos.Responses
{
    public class GetDiscountResponse
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}