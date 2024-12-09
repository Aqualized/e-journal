using EjournalBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {

        private readonly ILogger _logger;
        private readonly JournalDbContext _context;

        public SubjectRepository(ILogger logger, JournalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<string>> GetStudentSubjects(int studentId)
        {
            var subjects = await _context.Subjects
                .AsNoTracking()
                .Where(s => s.ScheduleLessons
                             .Any(sl => sl.GroupnumberNavigation.Students
                                            .Any(st => st.Studentid == studentId)))
                .Select(s => s.Subjectname)
                .Distinct()
                .ToListAsync();

            return subjects;
        }

        public async Task<IEnumerable<string>> GetGroupSubjects(string groupNumber)
        {
            var subjects = await _context.Subjects
                .AsNoTracking()
                .Where(s => s.ScheduleLessons
                             .Any(sl => sl.Groupnumber == groupNumber))
                .Select(s => s.Subjectname)
                .Distinct()
                .ToListAsync();

            return subjects;
        }

        public async Task<IEnumerable<string>> GetTeacherSubjects(int teacherId)
        {
            var subjects = await _context.Subjects
                .AsNoTracking()
                .Where(s => s.Teachers
                             .Any(ts => ts.Teacherid == teacherId))
                .Select(s => s.Subjectname)
                .Distinct()
                .ToListAsync();

            return subjects;
        }
    }
}