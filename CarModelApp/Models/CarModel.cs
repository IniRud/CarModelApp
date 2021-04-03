using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarModelApp.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Production { get; set; }

        public CarModel()
        {
            Id = -1;
            Model = "Nothing";
            Production = -1;
        }

        public CarModel(int id, string model, int production)
        {
            Id = id;
            Model = model;
            Production = production;
        }
    }
}