using BirthdayAPI.Core.Domain.Abstractions.Units;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Units
{
    public class SaveUnit : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public SaveUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
