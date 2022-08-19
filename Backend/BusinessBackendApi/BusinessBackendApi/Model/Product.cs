using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessBackendApi.Model
{
    [Table("tbProducts")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdRestaurant { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Product(int idRestaurant, string name, string description, decimal price)
        {
            Id = 0;
            IdRestaurant = idRestaurant;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
