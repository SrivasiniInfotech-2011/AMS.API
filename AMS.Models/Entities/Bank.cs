using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string MicrCode { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string BranchAddressLine1 { get; set; }
        public string BranchAddressLine2 { get; set; }
        public string BranchAddressCity { get; set; }
        public string BranchAddressPinCode { get; set; }
        public string BranchAddressCountry { get; set; }
        public string BranchAddressPhone { get; set; }
        public string BranchAddressMobile { get; set; }
        public string BranchEmail { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
    }
}
