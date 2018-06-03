using System;
using System.ComponentModel.DataAnnotations;
namespace DataSystem.Models
{
    public class TempFacility
    {
        [Display(Name ="ID")]
        [Key]
        public int? FacilityId { get; set; }
        [Display(Name = "District")]
        [Required(ErrorMessage="District is required.")]
        public string DistCode { get; set; }
        [Display(Name = "Facility Name")]
        [Required(ErrorMessage = "Facility is required.")]
        public string FacilityName { get; set; }
        [Display(Name = "Name Dari")]
        public string FacilityNameDari { get; set; }
        [Display(Name = "Name Pashtoo")]
        public string FacilityNamePashto { get; set; }
        [Display(Name = "Facility Type")]
        [Required(ErrorMessage = "Facility Type is required.")]
        public int? FacilityType { get; set; }
        public string Location { get; set; }
        [Display(Name = "Location Dari")]
        public string LocationDari { get; set; }
        [Display(Name = "Location Pashto")]
        public string LocationPashto { get; set; }
        public string ViliCode { get; set; }
        public Decimal? Lat { get; set; }
        public Decimal? Lon { get; set; }
        public string Implementer { get; set; }
        public string SubImplementer { get; set; }
        public string ActiveStatus { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateEstablished { get; set; }
    }

}