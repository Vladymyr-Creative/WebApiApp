using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BrandName { get; set; }

        public bool IsAvailable { get; set; }
    }
}
