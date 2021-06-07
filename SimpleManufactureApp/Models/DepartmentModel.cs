using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleManufactureApp.Models
{
    [Table("Department")]
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public ICollection<EmployeeModel> Employees { get; set; }

    }
}
