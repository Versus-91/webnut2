using System;
using System.ComponentModel.DataAnnotations;

namespace DataSystem.Models
{
    public partial class Districts
    {   [Required]
        [Display(Name = "District code")]
        public string DistCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string DistName { get; set; }
        [Display(Name = "Name Dari")]
        public string DistNameDari { get; set; }
        [Display(Name = "Name Pashto")]
        public string DistNamePashto { get; set; }
         [Required]
        public string ProvCode { get; set; }

        public virtual Provinces ProvCodeNavigation { get; set; }
    }
}
