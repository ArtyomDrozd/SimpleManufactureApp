using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleManufactureApp.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public virtual DepartmentModel Department { get; set; }
        public virtual ICollection<MissionModel> Missions { get; set; }



    }
}
