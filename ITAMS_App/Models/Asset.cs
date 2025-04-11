using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ITAMS_App.Models
{
public class Asset

{
    [Key]
    public int Asset_Id { get; set;}

    public required string Asset_Name { get; set; } = string.Empty;

    
    
    [Display(Name = "Asset Type")]
    [Column("AssetType_Id")]
    public int AssetType_Id { get; set; } // FK

    [ForeignKey("AssetType_Id")]
    public AssetType AssetType { get; set; } = default!;

    public required string Serial_Number {get; set;} = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime Purchase_Date {get; set;}
    public required string Status {get; set;}

   public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

}
}