namespace ITAMS_App.Models
{
public class MaintenanceRecord
{
    public int Record_Id { get; set; }
    public int Asset_Id { get; set; }
    public string Issue_Description { get; set; }
    public DateTime Maintenance_Date { get; set; }
    public string Technician_Name { get; set; }

    public Asset Asset { get; set; }
}
}