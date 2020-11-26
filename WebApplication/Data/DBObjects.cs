using WebApplication.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Customer.Any()) {
                content.Customer.AddRange(Customers);
            }
            if (!content.CarModel.Any()) {
                content.CarModel.AddRange(CarModels);
            }
            if (!content.CarTrim.Any()) {
                content.CarTrim.AddRange(CarTrims);
            }
            if (!content.CarVariant.Any()) {
                content.CarVariant.AddRange(CarVariants);
            }

            content.SaveChanges();
        }

        private static List<Customer> _customers;
        public static List<Customer> Customers
        {
            get {
                if (_customers == null) {
                    _customers = new List<Customer> {
                        new Customer {
                            Name="Rick",
                            Email= "rick@mail.co",
                            Phone="23456789"
                        },
                        new Customer {
                            Name="Alice",
                            Email= "aalice@mail.co",
                            Phone="87654321"
                        }
                    };
                }
                return _customers;
            }
            set { }
        }

        private static List<CarModel> _carModels;
        public static List<CarModel> CarModels
        {
            get {
                if (_carModels == null) {
                    _carModels = new List<CarModel> {
                        new CarModel {
                            Name="108",
                            BrandName= "Peugeot",
                            IsAvailable=true
                        },
                        new CarModel {
                            Name= "Corsa",
                            BrandName= "Opel",
                            IsAvailable=true
                        }
                    };
                }
                return _carModels;
            }
            set { }
        }

        private static List<CarTrim> _carTrims;
        public static List<CarTrim> CarTrims
        {
            get {
                if (_carTrims == null) {
                    _carTrims = new List<CarTrim> {
                        new CarTrim {
                            Name="Classic",
                            IsAvailable=true,
                            CarModelId=1
                        },
                        new CarTrim {
                            Name="Active",
                            IsAvailable=true,
                            CarModelId=1
                        },
                        new CarTrim {
                            Name="Standart",
                            IsAvailable=true,
                            CarModelId=2
                        },
                        new CarTrim {
                            Name="Pro",
                            IsAvailable=true,
                            CarModelId=2
                        }

                    };
                }
                return _carTrims;
            }
            set { }
        }

        private static List<CarVariant> _carVariants;
        public static List<CarVariant> CarVariants
        {
            get {
                if (_carVariants == null) {
                    _carVariants = new List<CarVariant> {
                        new CarVariant {
                            Engine="1.2 PureTech",
                            FuelType=FuelTypes.petrol,
                            GearType=GearTypes.manual,
                            Year=2018,
                            Price=99999,
                            IsAvailable=true,
                            CarTrimId=1
                        },
                        new CarVariant {
                            Engine="1.2 PureTech",
                            FuelType=FuelTypes.diesel,
                            GearType=GearTypes.manual,
                            Year=2019,
                            Price=90009,
                            IsAvailable=true,
                            CarTrimId=2
                        },
                        new CarVariant {
                            Engine="1.2 Turbo І3 100 h.p.",
                            FuelType=FuelTypes.petrol,
                            GearType=GearTypes.manual,
                            Year=2019,
                            Price=99999,
                            IsAvailable=true,
                            CarTrimId=3
                        },
                        new CarVariant {
                            Engine="1.2 Turbo І3 130 h.p.",
                            FuelType=FuelTypes.petrol,
                            GearType=GearTypes.manual,
                            Year=2018,
                            Price=88888,
                            IsAvailable=true,
                            CarTrimId=4
                        }

                    };
                }
                return _carVariants;
            }
            set { }
        }
    }
}

