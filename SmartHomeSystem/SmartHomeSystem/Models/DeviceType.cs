using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<NumberParameter> NumberParametersForDeviceType { get; set; }
        public ICollection<StringParameter> StringParametersForDeviceType { get; set; }
        public virtual ICollection<DeviceTypeAvailableValues> DeviceTypeAvailableValues { get; set; }

        public DeviceType()
        {
            DeviceTypeAvailableValues = new HashSet<DeviceTypeAvailableValues>();
        }
    }
}
