namespace EjournalBack.Domain.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public List<AttendanceDTO> Attendances { get; set; } = new();
    }
}
