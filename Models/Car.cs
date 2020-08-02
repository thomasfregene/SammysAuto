﻿using SammysAuto.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public string Style { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double Miles { get; set; }
        public string Color { get; set; }

        //foreign key
        public string  UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual SammysAutoApplicationUser ApplicationUser { get; set;  }
    }
}
