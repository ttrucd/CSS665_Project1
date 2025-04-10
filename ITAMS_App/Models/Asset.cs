using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITAMS_App.Models
{
public class Asset

{
    [Key]
    public int Asset_Id { get; set;}
    public required string Asset_Type {get; set;}
    public required string Serial_Number {get; set;}
    public DateTime Purchase_Date {get; set;}
    public required string Status {get; set;}

   public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

}
}