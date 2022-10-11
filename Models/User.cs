using System;

namespace AdminRegister.Models
{
    public class User
    {
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String UniqueUsername { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime MemberScince { get; set; }

    }
}
