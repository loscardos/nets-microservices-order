

using OrderService.Infrastructure.Dtos;

namespace OrderService.Domain.User.Dtos
{
    public class UserQueryDto : QueryDto
    {
        public string Email { get; set; }
    }
}