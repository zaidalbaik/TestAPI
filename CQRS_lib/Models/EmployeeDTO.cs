namespace CQRS_lib.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public float Salary { get; set; }

        public DateTime? HireDate { get; set; }

        public DepartmentDTO? Department { get; set; }
    }
}
