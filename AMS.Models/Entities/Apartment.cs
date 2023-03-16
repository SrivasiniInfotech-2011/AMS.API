using System;

namespace AMS.Models.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string ApartmentName { get; set; }
        public string ApartmentAddress { get; set; }
        public string RegistrationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ConstructionDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
