using OrderService.Infrastructure.Dtos;

namespace OrderService.Domain.Role.Dtos
{
    public class RoleQueryDto : QueryDto
    {
        public string Name { get; set; }
    }
}