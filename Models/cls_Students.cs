using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Studentsy", Schema = "BR")]
    public class cls_Students
    {
        [Key]
        [Display(Name = "StID")]
        public int StId { get; set; }


        [Display(Name = "StName")]
        public string StName { get; set; } = string.Empty;


        [Display(Name = "StPhone")]
        public string StPhone { get; set; }


        [Display(Name = "StAddress")]
        public string StAddress { get; set; }

        //public string  { get; set; } forCurs
        public int CurseId { get; set; }
        [ForeignKey("CurseId")]
        public cls_curse? curse { get; set; }


        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public cls_Type? type { get; set; }

        [Display(Name = "Image")]
        [Column(TypeName = "varchar(250)")]
        public string? TechImage { get; set; }
    }
}
