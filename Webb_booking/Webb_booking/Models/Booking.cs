using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Booker { get; set; }

        [Required]
        public Guid BirdId { get; set; }

        [Required]
        public string BirdName { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }
}
