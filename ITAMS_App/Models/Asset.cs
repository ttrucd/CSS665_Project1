namespace ITAMS_App.Models
{
public class Asset

{
    public int Asset_Id { get; set;}
    public string Asset_Type {get; set;}
    public string Serial_Number {get; set;}
    public DateTime Purchase_Date {get; set;}
    public string Status {get; set;}

    public ICollection<MaintenanceRecord> MaintenanceRecords {get; set;}
}
}