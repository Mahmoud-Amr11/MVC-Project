namespace Demo.Service.Dtos.DepartmentsDTO
{
    public class UpdateDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
    }
}
