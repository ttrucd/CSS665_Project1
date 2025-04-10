using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAMS_App.Models
{
    public class SoftwareLicense
    {
        [Key]
        public int License_Id { get; set; }

        public required string Software_Name { get; set; }

        public required string License_Key { get; set; }

        public DateTime Expiration_Date { get; set; }

        public int? Assigned_Employee_Id { get; set; }

        [ForeignKey("Assigned_Employee_Id")]
        public Employee? AssignedEmployee { get; set; } // optional navigation property
    }
}
