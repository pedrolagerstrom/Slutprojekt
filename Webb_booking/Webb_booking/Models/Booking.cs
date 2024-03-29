﻿using System;
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

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        [StringLength(30)]
        public string Booker { get; set; }

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        public Guid BirdId { get; set; }

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        public string BirdName { get; set; }

        [Required(ErrorMessage = "Välj ett datum.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Välj ett datum.")]
        public DateTime EndDate { get; set; }

        public string Species { get; set; }

    }
}
