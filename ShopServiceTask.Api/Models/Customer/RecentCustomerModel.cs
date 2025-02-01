namespace ShopServiceTask.Api.Models.Customer
{
    public class RecentCustomerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
