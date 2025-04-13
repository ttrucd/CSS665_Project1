using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAMS_App.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int Record_Id { get; set; }

        [ForeignKey("Asset")]
        public int Asset_Id { get; set; }

        public required string Issue_Description { get; set; } = string.Empty;

        public DateTime Maintenance_Date { get; set; }

        public required string Technician_Name { get; set; } = string.Empty;

        public Asset? Asset { get; set; }  // Navigation property
    }
}
