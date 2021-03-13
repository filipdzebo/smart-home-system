using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class AvailableVals
    {
        [Key]
        public int AvailableValuesId { get; set; }
        public string Value { get; set; }
        public virtual ICollection<DeviceTypeAvailableValues> DeviceTypeAvailableValues { get; set; }
        public AvailableVals()
        {
            DeviceTypeAvailableValues = new HashSet<DeviceTypeAvailableValues>();
        }
    }
}
