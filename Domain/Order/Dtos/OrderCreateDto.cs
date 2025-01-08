using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain.Order.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public Guid UserId { get; set; }

        public static Models.Order Assign(OrderCreateDto data)
        {
            Models.Order res = new()
            {
                ProductName = data.ProductName,
                Quantity = data.Quantity,
                UserId = data.UserId
            };

            return res;
        }
    }
}