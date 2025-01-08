using OrderService.Domain.Auth.Repositories;
using OrderService.Domain.Notification.Repositories;
using OrderService.Domain.Order.Repositories;
using OrderService.Domain.Permission.Repositories;
using OrderService.Domain.Role.Repositories;
using OrderService.Domain.User.Repositories;

namespace OrderService
{
    public partial class Startup
    {
        public void Repositories(IServiceCollection services)
        {
            services.AddScoped<AuthStoreRepository>();
            services.AddScoped<AuthQueryRepository>();
            services.AddScoped<UserQueryRepository>();
            services.AddScoped<UserStoreRepository>();
            services.AddScoped<RoleQueryRepository>();
            services.AddScoped<RoleStoreRepository>();
            services.AddScoped<PermissionQueryRepository>();
            services.AddScoped<PermissionStoreRepository>();
            services.AddScoped<NotificationQueryRepository>();
            services.AddScoped<NotificationStoreRepository>();
            services.AddScoped<OrderStoreRepository>();
            services.AddScoped<OrderQueryRepository>();
        }
    }
}
