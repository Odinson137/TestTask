using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Immutable;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Order> GetOrder()
        {
            return _context.Orders.OrderByDescending(c => c.Price).FirstAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _context.Orders.Where(c => c.Quantity > 10).ToListAsync();
        }
    }
}
