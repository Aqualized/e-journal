namespace EjournalBack.Domain.DTO
{
    public class AttendanceDTO
    {
        public DateOnly LessonDate { get; set; }
        public bool? IsPresent { get; set; }
        public string Reason { get; set; }
    }
}