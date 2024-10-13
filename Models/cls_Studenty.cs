using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Studenty", Schema = "BR")]
    public class cls_Studenty
    {
        [Key]
        [Display(Name = "StuyID")]
        public int StuyId { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "varchar(250)")]
        public string StuName { get; set; } = string.Empty;

        [Display(Name = "Phone")]
        [Column(TypeName = "varchar(250)")]
        public string StuPhone { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "varchar(250)")]
        public string StuAddress { get; set; }


        //public string  { get; set; } forCurs
        public int CurseId { get; set; }
        [ForeignKey("CurseId")]
        public cls_curse? curse { get; set; }

        //public string  { get; set; } forType
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public cls_Type? type { get; set; }

        [Display(Name = "Image")]
        [Column(TypeName = "varchar(250)")]
        public string? StuImage { get; set; }
    }
}
