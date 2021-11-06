using System;
using System.Collections.Generic;

#nullable disable

namespace DTP.Entity.Models
{
    public partial class User
    {
        public short Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public short? Points { get; set; }
    }
}
