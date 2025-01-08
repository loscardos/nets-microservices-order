using Microsoft.AspNetCore.Mvc;
using OrderService.Constants.Event;
using OrderService.Constants.Logger;
using OrderService.Domain.Order.Repositories;
using OrderService.Infrastructure.Exceptions;
using OrderService.Infrastructure.Dtos;
using OrderService.Domain.Order.Dtos;
using OrderService.Domain.Order.Messages;
using OrderService.Infrastructure.Integrations.NATs;
using OrderService.Infrastructure.Shareds;

namespace OrderService.Domain.Order.Services
{
    public class OrderService(
        OrderStoreRepository orderStoreRepository,
        OrderQueryRepository orderQueryRepository,
        NATsIntegration natsIntegration,
        ILoggerFactory loggerFactory
    )
    {
        private readonly OrderStoreRepository _orderStoreRepository = orderStoreRepository;
        private readonly OrderQueryRepository _orderQueryRepository = orderQueryRepository;
        private readonly NATsIntegration _natsIntegration = natsIntegration;
        private readonly ILogger _loggerIntegration = loggerFactory.CreateLogger(LoggerConstant.INTEGRATION);

        public async Task<PaginationModel<OrderResultDto>> Index(OrderQueryDto query)
        {
            var result = await _orderQueryRepository.Pagination(query);
            var formattedResult = OrderResultDto.MapRepo(result.Data);
            var paginate = PaginationModel<OrderResultDto>.Parse(formattedResult, result.Count, query);
            return paginate;
        }

        public async Task Create(OrderCreateDto dataCreate)
        {
            var create = OrderCreateDto.Assign(dataCreate);

            await _orderStoreRepository.Create(create);

            string subject = _natsIntegration.Subject(NATsEventModuleEnum.INVENTORY, NATsEventActionEnum.GET_BY_IDS,
                NATsEventStatusEnum.PROCESS);

            Dictionary<string, object> data = new()
            {
                { "productName", dataCreate.ProductName }, { "quantity", dataCreate.Quantity },
            };

            var reply = await _natsIntegration.PublishAndGetReply<object, object>(subject,
                Utils.JsonSerialize(data));

            OrderCreateEventDto orderCreateEventDto = Utils.JsonDeserialize<OrderCreateEventDto>(reply.ToString());
            
            Models.Order createdOrder = await _orderQueryRepository.FindLastInserted();

            if (createdOrder == null)
                throw new DataNotFoundException(OrderErrorMessage.ErrOrderNotFound);

            createdOrder.Status = orderCreateEventDto.Status == "ERROR" ? "Rejected" : "Confirmed";
            
            await _orderStoreRepository.Update(createdOrder.Id, createdOrder);
            
            if (orderCreateEventDto.Status == "ERROR")
                throw new BusinessException(orderCreateEventDto.Message);
        }

        public async Task<OrderResultDto> DetailById(Guid id)
        {
            var order = await _orderQueryRepository.FindOneById(id);

            if (order == null)
            {
                throw new DataNotFoundException(OrderErrorMessage.ErrOrderNotFound);
            }

            return new OrderResultDto(order);
        }

        public async Task<List<Models.Order>> GetList(string search, int page, int perPage)
        {
            return await _orderQueryRepository.Get(search, page, perPage);
        }

        public async Task<int> Count(string search)
        {
            return await _orderQueryRepository.CountAll(search);
        }

        public async Task Update(Guid id, OrderUpdateDto dataUpdate)
        {
            var data = OrderUpdateDto.Assign(dataUpdate);
            await _orderStoreRepository.Update(id, data);
        }

        public async Task Delete(Guid id)
        {
            await _orderStoreRepository.Delete(id);
        }
    }
}