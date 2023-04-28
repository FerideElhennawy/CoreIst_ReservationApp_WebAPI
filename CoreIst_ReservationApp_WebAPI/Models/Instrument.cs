using System.ComponentModel;

namespace CoreIst_ReservationApp_WebAPI.Models
{
    public class Instrument
    {
        public int Id {get; set;}
       //[DisplayName("Instrument Name")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int FacilityId { get; set; } 

    }
}
