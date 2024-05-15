using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string emailId { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

    }
}
