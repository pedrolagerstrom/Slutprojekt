using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string Booker { get; set; }
        public Guid BirdId { get; set; }
        public string BirdName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
