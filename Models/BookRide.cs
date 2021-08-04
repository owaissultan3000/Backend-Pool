using System;

namespace carpool.Models
{
    public class BookRide
    {
        public Guid BookingId { get; set; }
        public Guid PassengerId { get; set; }
        public Guid CaptainId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNumber { get; set; }
        public string PassengerDestination { get; set; }

        
    }
}