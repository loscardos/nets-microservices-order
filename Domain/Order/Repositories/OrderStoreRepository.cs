using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OrderService.Infrastructure.Databases;
using OrderService.Infrastructure.Exceptions;
using DbDeleteConcurrencyException = Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;


namespace OrderService.Domain.Order.Repositories
{
    public class OrderStoreRepository(
        IamDBContext context
    )
    {
        private readonly IamDBContext _context = context;

        public async Task Create(Models.Order orderRepository)
        {
            Models.Order newOrder = new()
            {
                ProductName = orderRepository.ProductName,
                Quantity = orderRepository.Quantity,
                UserId = orderRepository.UserId,
                Status = "Pending"
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Models.Order orderRepository)
        {
            try
            {
                var trackedEntity = await _context.Orders.FindAsync(id);
                
                if (trackedEntity == null)
                    throw new DataNotFoundException("Order not found.");

                _context.Entry(trackedEntity).CurrentValues.SetValues(orderRepository);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new UnprocessableEntityException("No data was updated.");
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                Models.Order data = new() { Id = id };
                _context.Orders.Attach(data);
                _context.Orders.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (DbDeleteConcurrencyException)
            {
                throw new UnprocessableEntityException("No data was deleted.");
            }
        }

        public async Task BulkSave(Models.Order[] data)
        {
            _context.Orders.AddRange(data);
            await _context.SaveChangesAsync();
        }
    }
}