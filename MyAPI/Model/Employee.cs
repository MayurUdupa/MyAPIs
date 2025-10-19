using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }
        public string Designation { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }

        public Department Department { get; set; }
        public ICollection<Salary> Salaries { get; set; }

    }
}
