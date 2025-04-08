namespace ITAMS_App.Models {


public class Employee 
{
    public int Employee_Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Department {get; set;}

   public int? Assigned_Asset_Id {get; set;}
   public Asset AssignedAsset {get; set;} 
}
}