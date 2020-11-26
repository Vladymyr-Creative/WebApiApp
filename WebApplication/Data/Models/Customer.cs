using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.Models
{
    public class Customer
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        [Required]
        [Remote(action: "IsValidEmail", controller: "Customer")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^\d+$")]        
        public string Phone { get; set; }
    }
}
