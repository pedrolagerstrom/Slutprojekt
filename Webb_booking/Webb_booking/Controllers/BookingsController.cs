using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webb_booking.Helpers;
using Webb_booking.Models;
using Webb_booking.Models.ViewModels;

namespace Webb_booking.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            List<Booking> bookings = DbContext.Bookings;
            List<Bird> birds = DbContext.Birds;
            List<IndexBookingViewModel> indexBookings = new List<IndexBookingViewModel>();

            //foreach (var booking in bookings)
            //{
            //    var price = birds.SingleOrDefault(b => b.Id == booking.BirdId).Price;
            //    long tickDifferens = booking.StartDate.Ticks - booking.EndDate.Ticks;
            //    long milliSec = tickDifferens / 10000;
            //    long sec = milliSec / 1000;
            //    long min = sec / 60;
            //    long hour = min / 60;
            //    long sum = hour * price;                
            //}

            

            return View(bookings);
        }

        public IActionResult Create()
        {
            CreateBookingViewModel createBookingViewModel = new CreateBookingViewModel { Birds = DbContext.Birds };
            return View(createBookingViewModel);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (!ValidateBooking(booking))
            {
                var createBookingViewModel = new CreateBookingViewModel() { Birds = DbContext.Birds, Booking = booking };
                return View(createBookingViewModel);
            }

            
            if (booking == null)
            {
                return NotFound();
            }

            Bird bird = DbContext.Birds.SingleOrDefault(bird => bird.Id == booking.BirdId);

            if (bird == null)
            {
                return NotFound();
            }

            booking.BirdName = bird.Name;
            booking.Species = bird.Species;
            booking.Id = Guid.NewGuid();

            DbContext.Bookings.Add(booking);

            return RedirectToAction(nameof(Index));
        }

        private bool ValidateBooking(Booking booking)
        {
            bool isValid = true;
                        
            if (booking.StartDate > booking.EndDate)
            {
                ModelState.AddModelError("Booking.StartDate", "Start datum kan inte vara före slut datum.");
                var createBookingViewModel = new CreateBookingViewModel() { Birds = DbContext.Birds, Booking = booking };
                isValid = false;
            }
                        
            List<Booking> bookingsFromDb = DbContext.Bookings.Where(b => b.BirdId == booking.BirdId).ToList();
                        
            foreach (var oldBooking in bookingsFromDb)
            {
                if (DateHelpers.HasSharedDateIntervals(booking.StartDate, booking.EndDate, oldBooking.StartDate, oldBooking.EndDate))
                {
                    ModelState.AddModelError("Booking.StartDate", "Det finns redan en bokning på denna tid.");
                    var createBookingViewModel = new CreateBookingViewModel() { Birds = DbContext.Birds, Booking = booking };
                    isValid = false;
                }
            }

            return isValid;
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = DbContext.Bookings.SingleOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            EditBookingViewModel editBookingViewModel = new EditBookingViewModel { Birds = DbContext.Birds, Booking = booking };

            return View(editBookingViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (booking == null)
            {
                return NotFound();
            }

            Bird bird = DbContext.Birds.SingleOrDefault(r => r.Id == booking.BirdId);

            if (bird == null)
            {
                return NotFound();
            }

            booking.BirdName = bird.Name;
            booking.Species = bird.Species;

            int bookingIndex = DbContext.Bookings.FindIndex(b => b.Id == booking.Id);

            if (bookingIndex == -1)
            {
                return NotFound();
            }

            DbContext.Bookings[bookingIndex] = booking;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking booking = DbContext.Bookings.SingleOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult DeleteConfirmed(Booking booking)
        {
            if (booking == null)
            {
                return NotFound();
            }

            int bookingIndex = DbContext.Bookings.FindIndex(b => b.Id == booking.Id);
            if (bookingIndex == -1)
            {
                return NotFound();
            }

            DbContext.Bookings.RemoveAt(bookingIndex);

            return RedirectToAction(nameof(Index));
        }
    }
}
