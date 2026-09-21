using Microsoft.AspNetCore.Identity;

namespace EmployeeLeaveManagementSystem_API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }=string.Empty;
        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        
        public int? EmployeeId { get; set; }    

        public Employee? Employee { get; set; }  



    }
}
