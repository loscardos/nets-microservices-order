using OrderService.Infrastructure.Dtos;

namespace OrderService.Domain.Order.Dtos
{
    public class OrderQueryDto : QueryDto
    {
        public string ProductName { get; set; }
    }
}
