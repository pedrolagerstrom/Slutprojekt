using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        [Required]
        public Booking Booking { get; set; }

        [Required]
        public List<Bird> Birds { get; set; }
    }
}
