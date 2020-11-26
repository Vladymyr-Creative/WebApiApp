namespace WebApplication.Data.ApiResponseModels
{
    public class BankLoanApiResponce
    {
        public double BankLoanAmount { get; set; }
        public double MonthlyPayment { get; set; }
        public double DebitoreRate { get; set; }
        public double? AopRate { get; set; }
        public double BorrowingInterestRate { get; set; }
        public double TotalCreditAmount { get; set; }
        public double TotalCashPayment { get; set; }
    }
}
