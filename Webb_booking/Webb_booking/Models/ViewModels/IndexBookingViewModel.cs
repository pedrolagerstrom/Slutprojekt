using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb_booking.Models.ViewModels
{
    public class IndexBookingViewModel
    {
        public Guid Id { get; set; }

        
        public string Booker { get; set; }

        
        public Guid BirdId { get; set; }

        
        public string BirdName { get; set; }

        
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        public int TotalPrice { get; set; }
    }
}
