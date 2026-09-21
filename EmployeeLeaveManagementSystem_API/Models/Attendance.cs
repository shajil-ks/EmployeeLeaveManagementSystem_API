namespace EmployeeLeaveManagementSystem_API.Models
{

    public enum AttendanceStatus
    {
        Present=1,
        Absent=2,
        HalfDay=3,
        OnLeave=4,
        WeekOff=5,
        Holiday=6


    }

    public class Attendance
    {
        public int Id { get; set; } 

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan? CheckInTime { get; set; }

        public TimeSpan? CheckOutTime { get; set; }

        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;

        public string? Remarks { get; set; }

    }
}
