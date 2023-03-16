using System;

namespace AMS.Models.Entities
{
    public class House
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int BlockId { get; set; }
        public int ApartmentId { get; set; }
        public string HouseNumber { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string BlockName { get; set; }
        public string ApartmentName { get; set; }
    }
}
