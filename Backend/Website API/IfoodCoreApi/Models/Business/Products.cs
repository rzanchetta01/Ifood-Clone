namespace IfoodCoreApi.Models.Business
{
    public class Products
    {
        public int Id { get; set; }
        public int Id_Restaurant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }

        public Products(int id, int id_Restaurant, string name, string description, byte[] image, decimal price)
        {
            Id = id;
            Id_Restaurant = id_Restaurant;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
