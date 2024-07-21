using System.ComponentModel.DataAnnotations;

namespace VmSqlDemoApp.Models.DTO
{
    public class AddNewProductDTO
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public IFormFile ProductImage { get; set; }


    }
}
