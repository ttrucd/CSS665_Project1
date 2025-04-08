namespace ITAMS_App.Models {
public class SoftwareLicense
{
    public int License_Id {get; set;}
    public string Software_Name {get; set;}
    public string License_Key {get; set;}
    public DateTime Expiration_Date { get; set;}

    public int? Assigned_Employee_Id {get; set;}
    public Employee AssignedEmployee {get; set;}
}
}