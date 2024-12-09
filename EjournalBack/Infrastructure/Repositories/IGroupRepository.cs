using EjournalBack.Domain.DTO;
using EjournalBack.Domain.Models;

namespace EjournalBack.Infrastructure.Repositories
{
    public interface IGroupRepository
    {
        Task<StudentGroup?> GetGroupByNumberAsync(string groupNumber);
        Task<List<GroupDTO>> GetGroupAsync(string subjectName);
        Task<GroupDTO?> GetGroupAsync(string subjectName, string groupNumber);
    }
}