using BackEnd.Context;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class ManagementService : IManagementService
    {
        private readonly AppDbContext _context;

        public ManagementService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Management>> GetManagements()
        {
            try
            {
                return await _context.Managements.ToListAsync();
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Management> GetManagement(int id)
        {
            var management = await _context.Managements.FindAsync(id);
            return management;
        }


        public async Task CreateManagement(Management management)
        {
            _context.Managements.Add(management);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManagement(Management management)
        {
            _context.Entry(management).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManagement(Management management)
        {
            _context.Managements.Remove(management);
            await _context.SaveChangesAsync();
        }

        public Task Getmanagements()
        {
            throw new NotImplementedException();
        }

        public Task DeleteManagement(object management)
        {
            throw new NotImplementedException();
        }
    }
}
