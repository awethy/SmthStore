using Microsoft.EntityFrameworkCore;
using SmthStore.Core.Models;
using SmthStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmthStore.DataAccess.Repositories
{
    public class SmthsRepository : ISmthsRepository
    {
        private readonly SmthStoreDbContext _context;

        public SmthsRepository(SmthStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Smth>> GetSmth()
        {
            var smthEntities = await _context.SmthEntities
                .AsNoTracking().ToListAsync();

            var smth = smthEntities
                .Select(b => Smth.Create(b.Id, b.Name, b.Description).Smth).ToList();

            return smth;
        }

        public async Task<Guid> Create(Smth smth)
        {
            var smthEntity = new SmthEntity
            {
                Id = smth.Id,
                Name = smth.Name,
                Description = smth.Description,
            };

            await _context.SmthEntities.AddAsync(smthEntity);
            await _context.SaveChangesAsync();

            return smthEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description)
        {
            await _context.SmthEntities
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Description, b => description));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.SmthEntities
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
