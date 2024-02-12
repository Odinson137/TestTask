﻿using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> GetUser()
        {
            return _context.Users.OrderByDescending(c => c.Orders.Count).FirstAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.Where(c => c.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}
