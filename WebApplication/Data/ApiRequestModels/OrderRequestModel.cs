using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.ApiRequestModels
{
    public class OrderRequestModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int VariantId { get; set; }

        [Required]
        [Range(20000, int.MaxValue, ErrorMessage = "The field Price can't be less 20000")]
        public int Price { get; set; }

        [Required]
        [Range(12, 96)]
        public int BankLoanDuration { get; set; }

        [Required]
        [Range(20000, int.MaxValue, ErrorMessage = "The field BankLoanDownPayment must be at least 20000")]
        public decimal BankLoanDownPayment { get; set; }

        [Required]        
        public decimal BankLoanMonthlyPayment { get; set; }

        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone must consists of 8 digits.")]
        public string CustomerPhone { get; set; }
    }
}
