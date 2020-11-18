using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Webb_booking.Models
{
    public static class DbContext
    {
        public static List<Bird> Birds { get; set; }
        public static List<Booking> Bookings { get; set; }

        static DbContext()
        {
            Birds = new List<Bird>();
            Bookings = new List<Booking>();

            Seed();
        }

        private static void Seed()
        {
            var bird1 = new Bird() { Id = Guid.NewGuid(), Species = "Grönvingad ara", Name = "Sir Talkalot", Price = 5000 };
            var bird2 = new Bird() { Id = Guid.NewGuid(), Species = "Undulat", Name = "Papa Jon", Price = 2000 };
            var bird3 = new Bird() { Id = Guid.NewGuid(), Species = "Nymfkakadua", Name = "Wendy", Price = 3000 };

            Birds.Add(bird1);
            Birds.Add(bird2);
            Birds.Add(bird3);


        }
    }
}
