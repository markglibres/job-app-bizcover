using System.Collections.Generic;

namespace BizCover.Api.Cars.Dtos.Requests
{
    public class GetDiscountRequest
    {
        public IEnumerable<int> Ids { get; set; }
    }
}