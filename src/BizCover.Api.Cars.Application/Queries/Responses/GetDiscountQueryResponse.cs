namespace BizCover.Api.Cars.Application.Queries.Responses
{
    public class GetDiscountQueryResponse
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}