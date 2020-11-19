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

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        [StringLength(30, ErrorMessage = "Art kan inte innehålla mer än 30 karaktärer")]
        public string Species { get; set; }

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        [StringLength(30, ErrorMessage = "Namn kan inte innehålla mer än 30 karaktärer")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fältet kan inte lämnas tomt.")]
        public int Price { get; set; }

        public byte[] Image { get; set; }
    }
}