using AutoMapper;
using EjournalBack.Domain.DTO;
using EjournalBack.Domain.Models;

namespace EjournalBack.Application.Helpers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<Student, StudentDTO>()
            .ForMember(dest => dest.FullName, 
                opt => opt.MapFrom(src => $"{src.Lastname} {src.Firstname} {src.Middlename}"))
            .ForMember(dest => dest.Attendances, opt => opt.MapFrom(src => src.StudentAttendances));

            CreateMap<StudentAttendance, AttendanceDTO>()
                .ForMember(dest => dest.LessonDate, opt => opt.MapFrom(src => src.Lesson.Date))
                .ForMember(dest => dest.IsPresent, 
                    opt => opt.MapFrom(src => src.Attendance.HasValue ? src.Attendance == 1 : (bool?)null));

            CreateMap<ScheduleLesson, GroupDTO>()
                .ForMember(dest => dest.GroupNumber, opt => opt.MapFrom(src => src.Groupnumber))
                .ForMember(dest => dest.Students, opt => opt.Ignore());

            CreateMap<SiteUser, UserDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}