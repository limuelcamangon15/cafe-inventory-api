namespace CafeInventoryApi.Models
{

    public class Item
    {
        public int Id {get; set;}
        public String Name {get; set;} = "";
        public String Category {get; set;} = "";
        public int Quantity {get; set;}
        public decimal Price {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}