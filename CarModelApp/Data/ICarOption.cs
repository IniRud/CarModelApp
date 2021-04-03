using CarModelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelApp.Data
{
    interface ICarOption
    {
        List<CarModel> GetAllCars();

        List<CarModel> SearchCar(string search);
        CarModel GetCarById(int id);
        int Insert(CarModel carModel);
        int Update(CarModel carModel);
    }
}
