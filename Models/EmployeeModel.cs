using System.ComponentModel.DataAnnotations;

namespace EmployeePayrollApp.Models
{
    public class EmployeeModel
    {
       // [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
    }
}
