using System.ComponentModel.DataAnnotations;

namespace ITAMS_App.Models
{
    public enum AdminPermission
    {
    FullAccess,
    IT,
    HR, 
    License
    }
public class Administrator 
{   
    //Primary Key for Administrator table
    [Key]
    public int Admin_Id {get; set;}
    public required string Name {get; set;}
    public required string Email {get; set;}
    public required string Department {get; set;}
    public AdminPermission Permission {get; set;}
}
}