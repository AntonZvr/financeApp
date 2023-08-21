namespace WebApp.Data.DAL.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }

}
