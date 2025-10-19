using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.Model
{
    public class Salary
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public decimal Amount { get; set; }

        public Employee Employee { get; set; }
    }
}
