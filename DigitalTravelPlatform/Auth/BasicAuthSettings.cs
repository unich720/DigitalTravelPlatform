using System.Collections.Generic;

namespace DigitalTravelPlatform.Auth
{
    public class BasicAuthSettings
    {
        public List<User> Users { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
