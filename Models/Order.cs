using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order : BaseModel
    {
        
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        public string Status { get; set; }
        
        public Guid UserId { get; set; }
        
    }
}