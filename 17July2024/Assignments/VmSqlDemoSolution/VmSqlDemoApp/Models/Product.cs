using System.ComponentModel.DataAnnotations;

namespace VmSqlDemoApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageDescription { get; set; }


    }
}
