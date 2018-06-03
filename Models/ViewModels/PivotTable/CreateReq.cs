

using System.ComponentModel.DataAnnotations;

namespace DataSystem.Models.ViewModels.PivotTable
{
    public class CreateReq
    {
        [RequiredAttribute]
        [Display(Name = "Province")]
        public string ProvCode { get; set; }

        [RequiredAttribute]
        public int Year { get; set; }
        public string Title { get; set; }
        [Range(1, 2)]
        public int option { get; set; }
        public string CollumnName { get; set; }
        public string FileName { get; set; }
        public string DistCode {get;set;}
        public int Facility{get;set;}
        public string Implementer {get;set;}
    }

}