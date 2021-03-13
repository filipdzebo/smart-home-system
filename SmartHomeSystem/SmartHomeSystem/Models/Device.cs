using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public Home DeviceHome { get; set; }
        public DeviceType DeviceType { get; set; }

        
    }
}
