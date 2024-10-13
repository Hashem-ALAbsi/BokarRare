using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Techares",Schema ="BR")]
    public class cls_Tectar
    {
        [Key]
        [Display(Name="ID")]
        public int TechId { get; set; }


        [Display(Name="Name")]
        public string TechName { get; set; } = string.Empty;


        [Display(Name="Phone")]
        public string TechPhone { get; set;}


        [Display(Name="Address")]
        public string TechAddress { get; set; }

        //public string  { get; set; } forCurs
        public int CurseId { get; set; }
        [ForeignKey("CurseId")]
        public cls_curse? curse { get; set; }


        [Display(Name ="Salary")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TechSal { get; set; }

        [Display(Name = "Image")]
        [Column(TypeName = "varchar(250)")]
        public string? TechImage { get; set; }
    }
}
