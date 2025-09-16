namespace Demo.Service.Dtos.EmployeesDTO
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string Gender { get; set; }
        public string EmployeeType { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
