using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class Archive
    {
        public int ArchiveId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        [ForeignKey("UpdatedDeviceId")]
        public Device UpdatedDevice { get; set; }
        [ForeignKey("UpdatedValueId")]
        public DeviceParameterCurrentValue UpdatedValue { get; set; }
    }
}
