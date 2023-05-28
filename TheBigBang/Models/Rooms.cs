using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBigBang.Models
{
    public class Rooms
    {
        [Key]
        public int Rid { get; set; }
        public string? Rtype { get; set; }
        public bool Vacancy { get; set; }
        public int Hid { get; set; }
        public Hotels? Hotel { get; set; }
    }
}
