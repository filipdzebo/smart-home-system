using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public Home DeviceHome { get; set; }
        [ForeignKey("DeviceTypeId")]
        public DeviceType DeviceType { get; set; }
        [ForeignKey("DPCurrentValue")]
        public DeviceParameterCurrentValue Device_Parameter_Current_Value { get; set; }
        public ICollection<Archive> Archives { get; set; }
        public virtual ICollection<DevicesCurrentValues> DevicesCurrentValues { get; set; }

        public Device()
        {
            DevicesCurrentValues = new HashSet<DevicesCurrentValues>();
        }
    }
}
