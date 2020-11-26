using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebApplication.Data.Models
{
    public enum FuelTypes
    {
        petrol,
        diesel,
        hybrid,
        ev
    }
    public enum GearTypes
    {
        manual,
        automatic
    }

    [MetadataType(typeof(CarOrder))]
    public class CarOrder
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string TrimName { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public FuelTypes FuelType { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public GearTypes GearType { get; set; }

        public int Price { get; set; }
        public int BankLoanDuration { get; set; }
        public decimal BankLoanDownPayment { get; set; }
        public decimal BankLoanMonthlyPayment { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
