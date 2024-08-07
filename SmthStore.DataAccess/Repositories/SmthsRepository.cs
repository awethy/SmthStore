using Microsoft.EntityFrameworkCore;
using SmthStore.Core.Models;
using SmthStore.DataAccess.Entities;

namespace SmthStore.DataAccess.Repositories
{
    public class SmthsRepository : ISmthsRepository
    {
        private readonly SmthStoreDbContext context;

        public SmthsRepository(SmthStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Smth>> GetSmth()
        {
            var smthEntities = await context.SmthEntities
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

            await context.SmthEntities.AddAsync(smthEntity);
            await context.SaveChangesAsync();

            return smthEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description)
        {
            await context.SmthEntities
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Description, b => description));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.SmthEntities
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
