namespace ShopServiceTask.Business.DTO
{
    public class GoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public GoodCategoryDTO Category { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
    }
}
