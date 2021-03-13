using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserHome> UserHome { get; set; }
        

        public User Owner { get; set; }
        public ICollection<Device> DevicesInHome { get; set; }
        public Home()
        {
            UserHome = new HashSet<UserHome>();
        }

    }
}
