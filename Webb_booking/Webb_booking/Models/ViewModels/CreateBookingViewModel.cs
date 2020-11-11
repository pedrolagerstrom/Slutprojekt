using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        public Booking Booking { get; set; }
        public List<Bird> Birds { get; set; }
    }
}
