using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Users", Schema = "BR")]
    public class cls_User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name ="User Name")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "User Passowrd")]
        public string UserPassowrd { get; set; } = string.Empty;

        //public string  { get; set; } forType
        public int TypeUserId { get; set; }
        [ForeignKey("TypeUserId")]
        public cls_TypeUser? typeUser { get; set; }
    }
}
