using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAMS_App.Models
{
    public enum Role {
        Admin, 
        Staff, 
        Student
    }
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Department { get; set; }

        public int? Assigned_Asset_Id { get; set; }

        [ForeignKey("Assigned_Asset_Id")]
        public Asset? AssignedAsset { get; set; } // optional navigation property
    

        public required string Role {get; set;}
    }
}
