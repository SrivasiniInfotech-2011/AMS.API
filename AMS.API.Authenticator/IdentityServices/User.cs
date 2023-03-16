namespace AMS.API.Authenticator.IdentityServices
{
    public class User
    {
        public int User_Id { get; set; }
        public string? User_First_Name { get; set; }
        public string? User_Last_Name { get; set; }
        public string? User_User_Name { get; set; }
        public string? User_Password { get; set; }
        public DateTime? User_Doj { get; set; }
        public DateTime? User_Dob { get; set; }
        public int User_Created_By { get; set; }
        public DateTime? User_Created_Date { get; set; }
        public int User_Modified_By { get; set; }
        public DateTime? User_Modified_Date { get; set; }
        public bool? User_IsActive { get; set; }
    }
}
