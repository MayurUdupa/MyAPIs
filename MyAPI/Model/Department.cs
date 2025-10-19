using System.ComponentModel.DataAnnotations;

namespace MyAPI.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
