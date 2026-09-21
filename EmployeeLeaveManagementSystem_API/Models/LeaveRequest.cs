namespace EmployeeLeaveManagementSystem_API.Models
{

    public enum LeaveStatus
    {
        Pending=1,
        Approved=2,
        Rejected=3,
        Cancelled=4


    }


    public class LeaveRequest
    {
        public int Id { get; set; } 

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }


        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double TotalDays { get; set; }

        public string Reason { get; set; } = string.Empty;
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;


        public int? ApprovedByEmployeeId { get; set; } 
        public Employee? ApprovedByEmployee { get; set; } 
        public DateTime? ActionedOn { get; set; }
        public string? ApproverComments { get; set; }




    }
}
