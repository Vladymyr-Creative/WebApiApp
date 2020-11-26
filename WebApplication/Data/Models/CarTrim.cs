using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.Models
{
    public class CarTrim
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }        
        public bool IsAvailable { get; set; }
        public int CarModelId{ get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
