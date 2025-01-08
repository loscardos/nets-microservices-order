using Microsoft.AspNetCore.Mvc;
using OrderService.Constants.Permission;
using OrderService.Domain.Order.Services;
using System.Net;
using OrderService.Infrastructure.Attributes;
using OrderService.Domain.Order.Dtos;
using OrderService.Infrastructure.Helpers;

namespace OrderService.Http.API.Version1.Order.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrderController(
        Domain.Order.Services.OrderService orderService
        ) : ControllerBase
    {
        private readonly Domain.Order.Services.OrderService _orderService = orderService;

        [HttpGet()]
        [Permissions(PermissionConstant.PERMISSION_VIEW)]
        public async Task<ApiResponse> Index([FromQuery] OrderQueryDto query)
        {
            var paginationResult = await _orderService.Index(query);
            return new ApiResponsePagination<OrderResultDto>(HttpStatusCode.OK, paginationResult);
        }

        [HttpGet("{id}")]
        [Permissions(PermissionConstant.PERMISSION_VIEW)]
        public async Task<ApiResponse> Show(Guid id)
        {
            var data = await _orderService.DetailById(id);
            return new ApiResponseData<OrderResultDto>(HttpStatusCode.OK, data);
        }

        [HttpPost()]
        [Permissions(PermissionConstant.PERMISSION_CREATE)]
        public async Task<ApiResponse> Store(OrderCreateDto dataCreate)
        {
            await _orderService.Create(dataCreate);
            return new ApiResponseData<OrderResultDto>(HttpStatusCode.OK, null);
        }

        [HttpPut("{id}")]
        [Permissions(PermissionConstant.PERMISSION_UPDATE)]
        public async Task<ApiResponse> Update(Guid id, OrderUpdateDto dataUpdate)
        {
            await _orderService.Update(id, dataUpdate);
            return new ApiResponseData<OrderResultDto>(HttpStatusCode.OK, null);
        }

        [HttpDelete("{id}")]
        [Permissions(PermissionConstant.PERMISSION_DELETE)]
        public async Task<ApiResponse> Delete(Guid id)
        {
            await _orderService.Delete(id);
            return new ApiResponseData<OrderResultDto>(HttpStatusCode.OK, null);
        }
    }
}
