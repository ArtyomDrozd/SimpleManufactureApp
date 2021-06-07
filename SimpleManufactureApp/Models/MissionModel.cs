using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleManufactureApp.Models
{
    [Table("Mission")]
    public class MissionModel
    {
        [Key]
        public int MissionId { get; set; }
        [Required]
        public string MissionName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<EmployeeModel> Employees { get; set; }
    }
}
