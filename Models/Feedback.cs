using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSystem.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Nmrid { get; set; }
        public string Initiator { get; set; }
        public string Respondent { get; set; }

        public string Problem { get; set; }
        public string Respose { get; set; }
        public virtual Nmr Nmr { get; set; }
        [NotMapped]
        public  ICollection<Feedback> items { get; set; }

    }
}
