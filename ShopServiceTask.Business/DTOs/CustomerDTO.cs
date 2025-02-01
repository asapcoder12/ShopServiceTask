namespace ShopServiceTask.Business.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<PurchaseDTO> Purchases { get; set; }
    }
}
