using BirthdayAPI.Abstractions;
using BirthdayAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Units
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
