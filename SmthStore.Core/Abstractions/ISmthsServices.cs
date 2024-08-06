using SmthStore.Core.Models;

namespace SmthStore.Application.Services
{
    public interface ISmthsServices
    {
        Task<Guid> CreateSmth(Smth smth);
        Task<Guid> DeleteSmth(Guid id);
        Task<List<Smth>> GetAllSmths();
        Task<Guid> UpdateSmth(Guid id, string name, string description);
    }
}