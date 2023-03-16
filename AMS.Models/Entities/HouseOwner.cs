using System;

namespace AMS.Models.Entities
{
    public class HouseOwner
    {
        public int HouseOwnerId { get; set; }
        public string HouseOwnerName { get; set; }
        public string HouseOwnerIdProof { get; set; }
        public string HouseOwnerAddress { get; set; }
        public string HouseOwnerEmail { get; set; }
        public string HouseOwnerMobile { get; set; }
        public int HouseOwnerHouseID { get; set; }
        public bool IsActive { get; set; }
        public int BlockID { get; set; }
        public int ApartmentID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
