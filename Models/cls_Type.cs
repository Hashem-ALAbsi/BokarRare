using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Types", Schema = "BR")]
    public class cls_Type
    {
        [Key]
        [Display(Name = "Type")]
        public int TypeId { get; set; }

        [Display(Name = "Type Name")]
        [Column(TypeName = "varchar(250)")]
        public string TypeName { get; set; } = string.Empty;
    }
}
