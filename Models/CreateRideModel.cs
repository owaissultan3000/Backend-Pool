using System;

namespace carpool.Models
{
    public class CreateRideModel
    {
        public Guid RideId { get; set; }
        public string CaptainId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleID { get; set; }
        public string JourneyRoute { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime DepartureTime { get; set; }
        public string FarePerSeats { get; set; }
    }
}