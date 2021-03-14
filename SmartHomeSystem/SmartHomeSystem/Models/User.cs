using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Home> Home { get; set; }
        public virtual ICollection<UserHome> UserHome { get; set; }

        public User()
        {
            UserHome = new HashSet<UserHome>();
        }

    }
}
