using SmthStore.Core.Models;

namespace SmthStore.DataAccess.Repositories
{
    public interface ISmthsRepository
    {
        Task<Guid> Create(Smth smth);
        Task<Guid> Delete(Guid id);
        Task<List<Smth>> GetSmth();
        Task<Guid> Update(Guid id, string name, string description);
    }
}