using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebApplication.Data.Models
{
    [MetadataType(typeof(CarVariant))]
    public class CarVariant
    {
        public int Id { get; set; }

        public string Engine { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FuelTypes FuelType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public GearTypes GearType { get; set; }
        [Range(2018, int.MaxValue)]
        public int Year { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CarTrimId { get; set; }
        [JsonIgnore]
        public virtual CarTrim CarTrim { get; set; }
    }
}
