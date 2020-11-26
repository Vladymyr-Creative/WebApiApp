namespace WebApplication.Data.ApiResponseModels
{
   public  class OrderApiResponce
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Engine { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public int Price { get; set; }
        public int BankLoanDuration { get; set; }
        public decimal BankLoanDownPament { get; set; }
        public decimal BankLoanMonthlyPayment { get; set; }        
    }
}
