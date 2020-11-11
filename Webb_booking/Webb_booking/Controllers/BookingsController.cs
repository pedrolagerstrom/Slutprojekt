using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webb_booking.Models;
using Webb_booking.Models.ViewModels;

namespace Webb_booking.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            List<Booking> bookings = DbContext.Bookings;
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
            booking.Id = Guid.NewGuid();

            DbContext.Bookings.Add(booking);

            return RedirectToAction(nameof(Index));
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
