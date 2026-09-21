using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLeaveManagementSystem_API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone, MaxLength(15)]
        public string? Phone { get; set; }

        public string Designation { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; } = DateTime.UtcNow;

        [Column(TypeName="decimal(18,2)")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;


        // Link to Identity user (for login)
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }


        // Link to Depertment
        public int? DepartmentId { get; set; }
        public Department? department { get; set; }


        //Self referencing

        public int? MangerId { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee> DirectReports { get; set; } = new List<Employee>();


        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    }
}
