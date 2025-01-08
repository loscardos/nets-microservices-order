using OrderService.Domain.Auth.Services;
using OrderService.Domain.File.Services;
using OrderService.Domain.Logging.Services;
using OrderService.Domain.Notification.Services;
using OrderService.Domain.Permission.Services;
using OrderService.Domain.Role.Services;
using OrderService.Domain.User.Services;
using OrderService.Infrastructure.Shareds;

namespace OrderService
{
    public partial class Startup
    {
        public void Services(IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<PermissionService>();
            services.AddScoped<RoleService>();

            services.AddScoped<LoggingService>();
            services.AddScoped<StorageService>();
            services.AddScoped<FileService>();

            services.AddScoped<NotificationService>();
            
            services.AddScoped<Domain.Order.Services.OrderService>();
        }
    }
}
