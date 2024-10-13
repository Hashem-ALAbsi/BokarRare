using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokarRare.Models
{
    [Table("Tbgads", Schema = "BR")]
    public class cls_tbgad
    {
        [Key]
        [Display(Name = "ID")]
        public int TDagrId { get; set; }


        public int StuyId { get; set; }
        [ForeignKey("StuyId")]
        public cls_Studenty? studenty { get; set; }

        [Display(Name = "HW")]
        public int StuHW { get; set; }

        [Display(Name = "MideXame")]
        public int MideXame { get; set; }

        [Display(Name = "FinalXame")]
        public int FinalXame { get; set; }

        [Display(Name = "Total")]
        public string Total { get; set; }

        [Display(Name = "Etamate")]
        public string Etamate { get; set; }
    }
}
