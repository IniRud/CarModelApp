using CarModelApp.Data;
using CarModelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarModelApp.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            List<CarModel> cars = new List<CarModel>();
            CarDAO carDAO = new CarDAO();
            cars = carDAO.GetAllCars();
            return View("Index", cars);
        }

        public ActionResult Details(int id)
        {
            CarDAO carDAO = new CarDAO();
            CarModel car = carDAO.GetCarById(id);
            return View("Details", car);
        }

        public ActionResult Create()
        {
            return View("CarForm");
        }

        public ActionResult Edit(int id)
        {
            CarDAO carDAO = new CarDAO();
            CarModel car = carDAO.GetCarById(id);
            return View("CarForm", car);
        }

        //Important
        public ActionResult Delete(int id)
        {
            CarDAO carDAO = new CarDAO();
            // show a list after deleting
            carDAO.Delete(id);
            List<CarModel> cars = carDAO.GetAllCars();
            return View("Index", cars);
        }
        [HttpPost]
        public ActionResult ProcessCreate(CarModel carModel)
        {
            CarDAO carDAO = new CarDAO();
            carDAO.Insert(carModel);
            return View("Details", carModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult Search(string search)
        {
            CarDAO carDAO = new CarDAO();
            List<CarModel> searchResults = carDAO.SearchCar(search);
            return View("Index", searchResults);
        }

    }
}