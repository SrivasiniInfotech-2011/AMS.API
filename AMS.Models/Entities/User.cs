using System;

namespace AMS.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime? UserDoj { get; set; }
        public DateTime? UserDob { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
