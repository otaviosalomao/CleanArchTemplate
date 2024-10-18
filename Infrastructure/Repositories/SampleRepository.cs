using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly SampleDbContext _context;

        public SampleRepository(SampleDbContext context)
        {
            _context = context;
        }

        public async Task<Sample> AddAsync(Sample entity)
        {
            await _context.Samples.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Sample entity)
        {
            _context.Samples.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sample>> GetAllAsync()
        {
            return await _context.Samples.ToListAsync();
        }

        public async Task<Sample?> GetByIdAsync(int id)
        {
            return await _context.Samples.FindAsync(id);
        }

        public async Task UpdateAsync(Sample entity)
        {
            _context.Samples.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sample>> GetSamplesWithOrdersAsync()
        {
            return await _context.Samples
                .Include(c => c.Name)
                .ToListAsync();
        }
    }
}
