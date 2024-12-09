namespace EjournalBack.Infrastructure.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<string>> GetStudentSubjects(int studentId);
        Task<IEnumerable<string>> GetGroupSubjects(string groupNumber);
        Task<IEnumerable<string>> GetTeacherSubjects(int teacherId);
    }
}