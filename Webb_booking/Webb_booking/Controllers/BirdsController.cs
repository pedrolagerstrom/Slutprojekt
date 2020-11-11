using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webb_booking.Models;

namespace Webb_booking.Controllers
{
    public class BirdsController : Controller
    {
        public IActionResult Index()
        {
            var birds = DbContext.Birds;
            return View(birds);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bird bird)
        {
            bird.Id = Guid.NewGuid();

            DbContext.Birds.Add(bird);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var bird = DbContext.Birds.SingleOrDefault(b => b.Id == id);

            if (bird == null)
            {
                return NotFound();
            }
            return View(bird);
        }

        [HttpPost]
        public IActionResult Edit(Bird bird)
        {
            if (bird == null)
            {
                return NotFound();
            }

            var birdIndex = DbContext.Birds.FindIndex(b => b.Id == bird.Id);

            if (birdIndex == -1)
            {
                return NotFound();
            }

            DbContext.Birds[birdIndex] = bird;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var bird = DbContext.Birds.FirstOrDefault(b => b.Id == id);

            if (bird == null)
            {
                return NotFound();
            }

            return View(bird);
        }

        [HttpPost]
        public IActionResult Delete(Bird bird)
        {
            var birdToDelete = DbContext.Birds.FirstOrDefault(b => b.Id == bird.Id);

            if (birdToDelete == null)
            {
                return NotFound();
            }

            DbContext.Birds.Remove(birdToDelete);

            return RedirectToAction("Index");
        }
    }
}
