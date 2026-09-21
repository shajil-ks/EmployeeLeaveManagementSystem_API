using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystem_API.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]

        public string Name { get; set; } = string.Empty;

        public int DefaultDaysPerYear { get; set; }
        [MaxLength(300)]
        public string? Description {  get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    }
}
    