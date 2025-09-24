using System.ComponentModel.DataAnnotations;

namespace Demo.Service.Dtos.EmployeesDTO
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1000, 100000, ErrorMessage = "Salary must be between 1000 and 100000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone number format")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Hiring date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Employee Type is required")]
        public string? EmployeeType { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters")]
        public string? CreatedBy { get; set; }
    }
}
