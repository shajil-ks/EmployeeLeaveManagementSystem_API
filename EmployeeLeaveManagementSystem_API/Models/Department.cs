using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystem_API.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required,MaxLength(100)]

        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
