﻿using SammysAuto.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Style { get; set; }
        public int Year { get; set; }
        public double Miles { get; set; }
        public string Color { get; set; }

        //foreign key
        public string  UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual SammysAutoApplicationUser ApplicationUser { get; set;  }
    }
}
