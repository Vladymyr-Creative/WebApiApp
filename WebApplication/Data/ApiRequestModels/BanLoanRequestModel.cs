using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.ApiRequestModels
{
    public class BankLoanApiRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int VariantId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Price{ get; set; }
        [Required]
        public decimal DownPayment { get; set; }
    }
}
