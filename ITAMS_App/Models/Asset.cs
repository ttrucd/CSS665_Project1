using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace ITAMS_App.Models
{
public enum AssetStatus
{
    [EnumMember(Value = "In Use")]
        InUse, 
        Available, 
        [EnumMember(Value = "Under Maintenance")]
        UnderMaintenance,
        Retired

}
public class Asset

{
    [Key]
    public int Asset_Id { get; set;}
   
   
    [Display(Name = "Asset Type")]
    public int AssetType_Id { get; set; } // FK

    [ForeignKey("AssetType_Id")]
    public AssetType? AssetType { get; set; } = default!;

    public required string Serial_Number {get; set;}

    [Required]
    [DataType(DataType.Date)]
    public DateTime Purchase_Date {get; set;}

    [Required]
    [Display(Name ="Asset Status")]
    public AssetStatus Status {get; set;}

   public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

}
}