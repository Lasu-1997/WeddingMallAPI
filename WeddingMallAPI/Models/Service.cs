namespace WeddingMallAPI.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get;set; }
        public string Image { get;set; }
        public string Phone_No { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
