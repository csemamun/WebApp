using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class RegistrationService : IRegistration
    {
        private readonly UserDbContext _context;

        public RegistrationService(UserDbContext context)
        {
            _context = context;
        }
       public async Task<Registration> Create(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task Delete(int id)
        {
            var reg = await _context.Registrations.FindAsync(id);
            _context.Remove(reg);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<Registration> GetById(int id)
        {
            return await _context.Registrations.FindAsync(id);
        }
        public async Task Update(Registration registration)
        {
            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
