using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models
{
    public class Bird
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Species { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public byte Image { get; set; }
    }
}