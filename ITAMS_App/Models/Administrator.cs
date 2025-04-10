using System.ComponentModel.DataAnnotations;

namespace ITAMS_App.Models
{
public class Administrator 
{
    [Key]
    public int Admin_Id {get; set;}
    public required string Name {get; set;}
    public required string Email {get; set;}
    public required string Department {get; set;}
    public required string Permission {get; set;}
}
}