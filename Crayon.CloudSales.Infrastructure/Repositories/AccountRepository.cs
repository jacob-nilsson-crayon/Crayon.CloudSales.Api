using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Repositories;
using Crayon.CloudSales.Infrastructure.Database.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Crayon.CloudSales.Infrastructure.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly CrayonCloudSalesDbContext _context;

        public AccountRepository(CrayonCloudSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync(string customerId)
        {
            var accountDbEntities = await _context.Accounts
                .Include(a => a.Licenses)
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();

            return accountDbEntities.Select(a => AccountDbMapper.ToAccount(a));
        }
    }
}
