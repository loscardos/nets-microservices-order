using OrderService.Infrastructure.Dtos;

namespace OrderService.Domain.Permission.Dtos
{
    public class PermissionQueryDto : QueryDto
    {
        public string Name { get; set; }
    }
}
