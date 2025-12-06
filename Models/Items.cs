namespace CafeInventoryApi.Models
{

    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;} = "";
        public string Category {get; set;} = "";
        public int Quantity {get; set;}
        public decimal Price {get; set;}
        public long CreatedAt {get; set;} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        public long? UpdatedAt {get; set;} = null;
    }
}