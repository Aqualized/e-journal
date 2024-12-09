using EjournalBack.Domain.DTO;
using EjournalBack.Domain.Models;

namespace EjournalBack.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<UserDTO?> GetByLogin(string login);
        Task<UserDTO?> Authorize(string login, string passwordHash);
    }
}