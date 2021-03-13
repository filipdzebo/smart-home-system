using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class StringParameter
    {
        public int StringParameterId { get; set; }
        public string Name { get; set; }
        public bool IsLimitedToAvailableValue { get; set; }
        public string DefaultValue { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
