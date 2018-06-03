using System;
using System.ComponentModel.DataAnnotations;

namespace DataSystem.Models
{
    public partial class TblStockIpt
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter a valid number")]
        public int SstockId { get; set; }
        [Required]
        public string Nmrid { get; set; }
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Openingbalance { get; set; }
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Received { get; set; }
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Used { get; set; }

        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Expired { get; set; }
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Damaged { get; set; }
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid number")]
        public decimal? Loss { get; set; }
        public string UserName { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual TlkpSstock Sstock { get; set; }
        public virtual Nmr Nmr { get; set; }

    }
}
