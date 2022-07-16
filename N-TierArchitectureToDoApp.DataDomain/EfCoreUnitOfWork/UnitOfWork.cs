using N_TierArchitectureToDoApp.DataDomain.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.DataDomain.EfCoreUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoAppDbContext _context;

        public UnitOfWork(ToDoAppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
