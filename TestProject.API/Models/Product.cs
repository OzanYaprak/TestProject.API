﻿using System.ComponentModel.DataAnnotations;

namespace TestProject.API.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
    }
}
