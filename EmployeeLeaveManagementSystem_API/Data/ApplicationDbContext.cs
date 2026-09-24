using EmployeeLeaveManagementSystem_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem_API.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Attendance> Attendances =>Set<Attendance>();
        public DbSet<Department> Departments =>Set<Department>();
        public DbSet<Employee> Employees =>Set<Employee>();
        public DbSet<Holiday> Holidays =>Set<Holiday>();
        public DbSet<LeaveRequest> LeaveRequests =>Set<LeaveRequest>();
        public DbSet<LeaveType> LeaveTypes =>Set<LeaveType>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Employee-Department
            builder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            //Employee-IdentityUser
            builder.Entity<Employee>()
                .HasOne(e=>e.User)
                .WithOne(u=>u.Employee)
                .HasForeignKey<Employee>(e =>e.ApplicationUserId)
                .OnDelete(DeleteBehavior.SetNull);

            //Attendance-Employee
            builder.Entity<Attendance>()
                .HasOne(a =>a.Employee)
                .WithMany(e =>e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Attendance>()
                .HasIndex(a => new { a.EmployeeId, a.Date })
                .IsUnique();

            //SelfReference
            builder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(e => e.DirectReports)
                .HasForeignKey(e => e.MangerId)
                .OnDelete(DeleteBehavior.Restrict);


            //LeaveRequest-Employee
            builder.Entity<LeaveRequest>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            //LeaveRequest-Employee(approver)
            builder.Entity<LeaveRequest>()
                .HasOne(l => l.Employee)
                .WithMany(e =>e.ApprovedLeaveRequests)
                .HasForeignKey(l => l.ApprovedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            //LeaveRequest-LeaveType
            builder.Entity<LeaveRequest>()
                .HasOne(l => l.LeaveType)
                .WithMany(t => t.LeaveRequests)
                .HasForeignKey(l => l.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);



                






        }





    }
}
