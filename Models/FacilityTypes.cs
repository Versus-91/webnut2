using System.ComponentModel.DataAnnotations;

namespace DataSystem.Models
{
    public partial class FacilityTypes
    {
        [Display(Name = "Code")]
        public int FacTypeCode { get; set; }
        [Display(Name = "Cat Code")]
        public int? FacTypeCatCode { get; set; }
        [Display(Name = "Type ")]
        public string FacType { get; set; }
        [Display(Name = "Type Dari")]
        public string FacTypeDari { get; set; }
        [Display(Name = "Type Pashto")]
        public string FacTypePashto { get; set; }
    }
}
