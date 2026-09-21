using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystem_API.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]

        public string Name { get; set; } = string.Empty;
        
        public DateTime Date { get; set; }
        [MaxLength(300)]

        public string? Description { get; set; } 

        public bool IsOptional { get; set; }=false;


    }
}
