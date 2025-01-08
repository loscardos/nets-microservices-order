namespace OrderService.Domain.Order.Dtos
{
    public class OrderResultDto : Models.Order
    {
        public OrderResultDto(Models.Order inventory)
        {
            Id = inventory.Id;
            ProductName = inventory.ProductName;
            Quantity = inventory.Quantity;
            Status = inventory.Status;
            CreatedAt = inventory.CreatedAt;
            UpdatedAt = inventory.UpdatedAt;
        }

        public static List<OrderResultDto> MapRepo(List<Models.Order> data)
        {
            return data?.Select(inventory => new OrderResultDto(inventory)).ToList();
        }
    }
}