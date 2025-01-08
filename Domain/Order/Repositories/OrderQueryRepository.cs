using System.Linq.Expressions;
using OrderService.Domain.Order.Dtos;
using OrderService.Infrastructure.Databases;
using OrderService.Infrastructure.Dtos;
using OrderService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Domain.Order.Repositories
{
    public class OrderQueryRepository(
        IamDBContext context
    )
    {
        private readonly IamDBContext _context = context;

        public async Task<PaginationResult<Models.Order>> Pagination(OrderQueryDto queryParams)
        {
            int skip = (queryParams.Page - 1) * queryParams.PerPage;
            var query = _context.Orders
                .AsQueryable()
                .AsNoTracking();

            query = QuerySearch(query, queryParams);
            query = QueryFilter(query, queryParams);
            query = QuerySort(query, queryParams);

            var data = await query.Skip(skip).Take(queryParams.PerPage).ToListAsync();
            var count = await Count(query);

            return new PaginationResult<Models.Order> { Data = data, Count = count, };
        }

        private static IQueryable<Models.Order> QuerySearch(IQueryable<Models.Order> query,
            OrderQueryDto queryParams)
        {
            if (queryParams.Search != null)
            {
                query = query.Where(data =>
                    data.ProductName.Contains(queryParams.Search));
            }

            return query;
        }

        private static IQueryable<Models.Order> QueryFilter(IQueryable<Models.Order> query,
            OrderQueryDto queryParams)
        {
            if (queryParams.ProductName != null)
            {
                query = query.Where(data => data.ProductName.Equals(queryParams.ProductName));
            }

            return query;
        }

        private static IQueryable<Models.Order> QuerySort(IQueryable<Models.Order> query,
            OrderQueryDto queryParams)
        {
            queryParams.SortBy ??= "updated_at";

            Dictionary<string, Expression<Func<Models.Order, object>>> sortFunctions = new()
            {
                { "name", data => data.ProductName },
                { "updated_at", data => data.UpdatedAt },
                { "created_at", data => data.CreatedAt },
            };

            if (!sortFunctions.TryGetValue(queryParams.SortBy, out Expression<Func<Models.Order, object>> value))
            {
                throw new BadHttpRequestException(
                    $"Invalid sort column: {queryParams.SortBy}, available sort columns: " +
                    string.Join(", ", sortFunctions.Keys));
            }

            query = queryParams.Order == SortOrder.Asc
                ? query.OrderBy(value).AsQueryable()
                : query.OrderByDescending(value).AsQueryable();

            return query;
        }

        public async Task<int> Count(IQueryable<Models.Order> query)
        {
            return await query.Select(x => x.Id).CountAsync();
        }

        public async Task<Models.Order> FindOneById(Guid id = default)
        {
            return await _context.Orders
                .Where(data => data.Id == id)
                .SingleOrDefaultAsync();
        }
        
        public async Task<Models.Order> FindLastInserted()
        {
            return await _context.Orders.AsNoTracking()
                .OrderByDescending(data => data.CreatedAt) 
                .FirstOrDefaultAsync(); 
        }
        
        public async Task<List<Models.Order>> Get(string search, int page, int perPage)
        {
            int skip = (1 - page) * perPage;
            List<Models.Order> permissions;
            IQueryable<Models.Order> permissionQuery = _context.Orders;
            if (search != null)
            {
                permissionQuery = permissionQuery.Where(permission => permission.ProductName.Contains(search));
            }

            permissions = await permissionQuery.Skip(skip).Take(perPage).ToListAsync();

            return permissions;
        }

        public async Task<int> CountAll(string search)
        {
            IQueryable<Models.Order> permissionQuery = _context.Orders;
            if (search != null)
            {
                permissionQuery = permissionQuery.Where(permission => permission.ProductName.Contains(search));
            }

            return await permissionQuery.CountAsync();
        }
        
        public async Task<bool> IsQuantityAvailable(string productName, int requiredQuantity)
        {
            var inventory = await _context.Orders
                .FirstOrDefaultAsync(p => p.ProductName == productName);

            if (inventory == null)
                throw new BadHttpRequestException($"inventory with name '{productName}' does not exist.");

            return inventory.Quantity >= requiredQuantity;
        }
    }
}