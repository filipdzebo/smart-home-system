using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Models
{
    public class DeviceTypeAvailableValues
    {
        [Key]
        public int DeviceTypeAvailableValuesId { get; set; }
        [Column(Order = 0), ForeignKey("DeviceType")]
        public int DeviceTypeId { get; set; }
        [Column(Order = 1), ForeignKey("AvailableVals")]
        public int AvailableValsId { get; set; }
    }
}
