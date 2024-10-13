using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Curses",Schema ="BR")]
    public class cls_curse
    {
        [Key]
        [Display(Name = "CurID")]
        public int CurseId { get; set; }

        [Display(Name = "Curse Name")]
        [Column(TypeName = "varchar(250)")]
        public string CurseName { get; set; } = string.Empty;
    }
}
