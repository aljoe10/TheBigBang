using System.ComponentModel.DataAnnotations;

namespace TheBigBang.Models
{
    public class Hotels
    {
        [Key]
        public int Hid { get; set; }
        public string? Hname { get; set; }
        public string? Hcity { get; set; }
        public int Hprice { get; set; }
        public int Hrating { get; set; }
        public ICollection<Rooms>? Room { get; set; }
    }
}
