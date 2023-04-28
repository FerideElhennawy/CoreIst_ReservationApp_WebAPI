using System.ComponentModel.DataAnnotations;

namespace CoreIst_ReservationApp_WebAPI.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<Instrument>? Instruments { get; set; }
    }
}
