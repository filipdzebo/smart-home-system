using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHomeSystem.Models
{
    public class UserHome
    {
        [Key]
        public int UserHomeId { get; set; }
        [Column(Order = 0), ForeignKey("Home")]
            public int HomeId { get; set; }
            [Column(Order = 1), ForeignKey("User")]
            public int UserId { get; set; }
        
    }
}