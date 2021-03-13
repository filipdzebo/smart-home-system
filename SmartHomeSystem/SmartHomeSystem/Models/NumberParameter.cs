using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class NumberParameter
    {
        public int NumberParameterId { get; set; }
        public string Name { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int DefaultValue { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
