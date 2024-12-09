using AutoMapper;
using EjournalBack.Domain.DTO;
using EjournalBack.Domain.Models;
using EjournalBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace EjournalBack.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ILogger _logger;
        private readonly JournalDbContext _context;
        private readonly IMapper _mapper;

        public GroupRepository(ILogger logger, JournalDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentGroup?> GetGroupByNumberAsync(string groupNumber)
        {
            var group = await _context.StudentGroups
                .AsNoTracking()
                .Where(g => g.Groupnumber == groupNumber)
                .Include(g => g.Students)
                .Include(g => g.ScheduleLessons)
                .Distinct()
                .FirstOrDefaultAsync();

            return group;
        }

        public async Task<List<GroupDTO>> GetGroupAsync(string subjectName)
        {
            var scheduleLessons = await _context.ScheduleLessons
                .Where(sl => sl.Subjectname == subjectName)
                .Include(sl => sl.GroupnumberNavigation.Students)
                .ThenInclude(s => s.StudentAttendances)
                .ThenInclude(a => a.Lesson)
                .ToListAsync();

            var groups = scheduleLessons
                .GroupBy(sl => sl.Groupnumber)
                .Select(group =>
                {
                    var groupDto = _mapper.Map<GroupDTO>(group.First());
                    groupDto.Students = group.SelectMany(sl => sl.GroupnumberNavigation.Students)
                        .Distinct()
                        .Select(student =>
                        {
                            var studentDto = _mapper.Map<StudentDTO>(student);
                            studentDto.Attendances = student.StudentAttendances
                                .Where(a => group.Any(sl => sl.Scheduleid == a.Lesson.Scheduleid))
                                .Select(a => _mapper.Map<AttendanceDTO>(a))
                                .ToList();

                            return studentDto;
                        }).ToList();

                    return groupDto;
                }).ToList();

            return groups;
        }

        public async Task<GroupDTO?> GetGroupAsync(string subjectName, string groupNumber)
        {
            var group = await _context.StudentGroups
                .Include(g => g.Students)
                .FirstOrDefaultAsync(g => g.Groupnumber == groupNumber);

            if (group == null)
            {
                return null;
            }

            var students = group.Students.Select(student => new StudentDTO
            {
                FullName = $"{student.Lastname} {student.Firstname} {student.Middlename}",
                Attendances = _context.StudentAttendances
                .Where(sa => 
                    sa.Studentid == student.Studentid &&
                    _context.ScheduleLessons
                        .Where(sl => sl.Groupnumber == groupNumber && sl.Subjectname == subjectName)
                        .Select(sl => sl.Scheduleid)
                        .Contains(sa.Lesson.Scheduleid)
                )
                .Select(sa => new AttendanceDTO
                {
                    LessonDate = sa.Lesson.Date,
                    IsPresent = sa.Attendance.HasValue ? sa.Attendance == 1 : (bool?)null,
                    Reason = sa.Reason
                }).ToList()
            }).ToList();

            return new GroupDTO
            {
                GroupNumber = group.Groupnumber,
                Students = students
            };
        }
    }
}