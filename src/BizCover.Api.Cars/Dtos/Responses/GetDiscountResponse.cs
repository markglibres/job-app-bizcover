namespace BizCover.Api.Cars.Dtos.Responses
{
    public class GetDiscountResponse
    {
        public decimal Discount { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}