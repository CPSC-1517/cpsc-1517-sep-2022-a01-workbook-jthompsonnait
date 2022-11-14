#nullable disable
#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion


namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 1,ErrorMessage ="Territory ID  is required and limited to 20")]
        public string TerritoryID { get; set; }

        [Required(ErrorMessage = "Territory description is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Territory description limited to 50")]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }
    }
}
