using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class DeviceParameterCurrentValue
    {
        [Key]
        public int DeviceParamCurrentValId { get; set; }
        public string Value { get; set; }

        public ICollection<Device> Devices { get; set; }
        public ICollection<Archive> Archives { get; set; }
        public virtual ICollection<DevicesCurrentValues> DevicesCurrentValues { get; set; }

        public DeviceParameterCurrentValue()
        {
            DevicesCurrentValues = new HashSet<DevicesCurrentValues>();
        }
    }
}
