﻿using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string size { get; set; }
        public float price { get; set; }

        public string Availability { get; set; }

    }
}
