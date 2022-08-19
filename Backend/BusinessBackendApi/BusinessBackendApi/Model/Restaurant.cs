using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessBackendApi.Model
{
    [Table("tbRestaurant")]
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        public Restaurant(string username, string password, string email, string name, string adress)
        {
            Id = 0;
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Adress = adress;
        }
    }
}
