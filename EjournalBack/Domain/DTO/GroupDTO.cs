namespace EjournalBack.Domain.DTO
{
    public class GroupDTO
    {
        public string GroupNumber { get; set; } = string.Empty;
        public List<StudentDTO> Students { get; set; } = new();
    }


}