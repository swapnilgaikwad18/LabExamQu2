using LabExamQu2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabExamQu2.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        public ActionResult Index()
        {
            List<Car> lstcar = Car.GetAllCars();
            return View(lstcar);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Car car = Car.GetSingleCar(id.Value);
                return View(car);
            }
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                Car.InsertCar(car);
                ViewBag.message = "Success!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Car car = Car.GetSingleCar(id.Value);
                return View(car);
            }
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                Car.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Car car = Car.GetSingleCar(id.Value);
                return View(car);
            }
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Car.DeleteCar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
