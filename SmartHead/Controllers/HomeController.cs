using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MvcApplication.Enums;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public class MyClass
        {
            public IEnumerable<Car> Cars { get; set; }

            public PageInfo PageInfo { get; set; }
        }
        private readonly CarContext _db = new CarContext();
        public ActionResult Index(int page = 1, SortState sortOrder = SortState.NumberAsc)
        {
            var cars = _db.Cars.ToList();

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["NumberSort"] = sortOrder == SortState.NumberAsc ? SortState.NumberDesc : SortState.NumberAsc;

            var pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = 3,
                TotalItems = cars.Count
            };

            cars = _db.Cars.ToList().Skip((page - 1) * 3).Take(3).ToList();

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    cars = cars.OrderByDescending(s => s.Name).ToList();
                    break;
                case SortState.NameAsc:
                    cars = cars.OrderBy(s => s.Name).ToList();
                    break;
                case SortState.NumberAsc:
                    cars = cars.OrderBy(s => s.Number).ToList();
                    break;
                case SortState.NumberDesc:
                    cars = cars.OrderByDescending(s => s.Number).ToList();
                    break;
                case SortState.CreateDateAsc:
                    cars = cars.OrderBy(s => s.CreateDate).ToList();
                    break;
                case SortState.CreateDateDesc:
                    cars = cars.OrderByDescending(s => s.CreateDate).ToList();
                    break;
                case SortState.ChangeDateAsc:
                    cars = cars.OrderBy(s => s.CreateDate).ToList();
                    break;
                case SortState.ChangeDateDesc:
                    cars = cars.OrderByDescending(s => s.CreateDate).ToList();
                    break;
            }

            return View(new MyClass
            {
                Cars = cars,
                PageInfo = pageInfo
            });
        }

        [HttpGet]
        public ActionResult EditCar(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            var newCar = _db.Cars.Find(car.Id);
            newCar.Name = car.Name;
            newCar.ChangeDate = DateTime.Now;

            _db.Entry(newCar).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            car.CreateDate = DateTime.Now;
            car.ChangeDate = DateTime.Now;
            car.Number = _db.Cars.Count() + 1;

            _db.Cars.Add(car);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Car b = new Car { Id = id };
            _db.Entry(b).State = EntityState.Deleted;
            _db.SaveChanges();

            var index = 1;
            foreach (var row in _db.Cars)
            {
                row.Number = index++;
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}