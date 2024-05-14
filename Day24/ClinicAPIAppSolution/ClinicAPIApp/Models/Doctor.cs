using System.ComponentModel.DataAnnotations;

namespace ClinicAPIApp.Models
{
    public class Doctor
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }

        public int? Experience {  get; set; } 
       

    }
}
