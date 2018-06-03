namespace DataSystem.Models.ViewModels
{
    public class stockoutDto
    {
        public int StockId { get; set; }
        public string Nmrid { get; set; }
        public decimal? Openingbalance { get; set; }
        public decimal? Received { get; set; }
        public decimal? Used { get; set; }
        public decimal? Expired { get; set; }
        public decimal? Damaged { get; set; }
        public decimal? Loss { get; set; }
        public string Item { get; set; }
        public string UserName { get; set; }

    }
}
