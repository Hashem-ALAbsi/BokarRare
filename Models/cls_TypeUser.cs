using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("TypeUsers", Schema = "BR")]
    public class cls_TypeUser
    {
        [Key]
        [Display(Name = "Type")]
        public int TypeUserId { get; set; }

        [Display(Name = "Type Name")]
        [Column(TypeName = "varchar(250)")]
        public string TypeUserName { get; set; } = string.Empty;
    }
}
