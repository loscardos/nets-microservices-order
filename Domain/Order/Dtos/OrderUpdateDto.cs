using OrderService.Constants.Order;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain.Order.Dtos
{
    public class OrderUpdateDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public OrderStatus Status { get; set; }

        public static Models.Order Assign(OrderUpdateDto data)
        {
            Models.Order res = new()
            {
                ProductName = data.ProductName,
                Status = data.Status.ToString(),
            };

            return res;
        }
    }
}