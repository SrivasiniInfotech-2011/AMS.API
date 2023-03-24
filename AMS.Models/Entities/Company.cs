using System;

namespace AMS.Models.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAliasName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPinCode { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMphone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyTINNO { get; set; }
        public string CompanyTINGSTNo { get; set; }
        public string CompanyPANNo { get; set; }
        public string CompanyBankName { get; set; }
        public string CompanyBankBranch { get; set; }
        public string CompanyBankAccountNo { get; set; }
        public string CompanyBankIFSCCode { get; set; }
        public string CompanyFontName { get; set; }
        public int? CompanyFontSize { get; set; }
        public string CompanyFontStyle { get; set; }
        public string CompanyAddress1FontName { get; set; }
        public int? CompanyAddress1FontSize { get; set; }
        public string CompanyAddress1FontStyle { get; set; }
        public string CompanyCurrencyName { get; set; }
        public string CompanyCurrencyCode { get; set; }
        public string CompanyCurrencySymbol { get; set; }
        public string CompanyCurrencyPaise { get; set; }
        public decimal? CompanyCurrencyExchange { get; set; }
        public bool? CompanyActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifedBy { get; set; }
        public DateTime? ModifedDate { get; set; }
        public string CompanyPrefix { get; set; }
        public DateTime? CompanyStartDate { get; set; }
    }
}
