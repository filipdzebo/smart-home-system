using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class DevicesCurrentValues
    {
        public int DevicesCurrentValuesId { get; set; }
        [Column(Order = 0), ForeignKey("Device")]
        public int DeviceId { get; set; }
        [Column(Order = 1), ForeignKey("DeviceParameterCurrentValue")]
        public int DeviceParameterCurrentValueId { get; set; }
    }
}
