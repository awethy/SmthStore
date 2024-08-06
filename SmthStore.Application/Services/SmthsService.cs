using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SmthStore.Core.Models;
using SmthStore.DataAccess.Repositories;

namespace SmthStore.Application.Services
{
    public class SmthsService : ISmthsServices
    {
        private readonly SmthsRepository smthsRepository;

        public SmthsService(SmthsRepository smthsRepository)
        {
            this.smthsRepository = smthsRepository;
        }

        public async Task<List<Smth>> GetAllSmths()
        {
            return await smthsRepository.GetSmth();
        }

        public async Task<Guid> CreateSmth(Smth smth)
        {
            return await smthsRepository.Create(smth);
        }

        public async Task<Guid> UpdateSmth(Guid id, string name, string description)
        {
            return await smthsRepository.Update(id, name, description);
        }

        public async Task<Guid> DeleteSmth(Guid id)
        {
            return await smthsRepository.Delete(id);
        }
    }
}
