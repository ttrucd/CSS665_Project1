using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITAMS_App.Models {
    
    public class AssetType {
        [Key]
        public int AssetType_Id {get; set;}

        [Required]
        [Display(Name = "Asset Type Name")]
        public string Type_Name {get; set;} = string.Empty;

        public ICollection<Asset>? Assets {get; set;} = new List<Asset>();
    }
}