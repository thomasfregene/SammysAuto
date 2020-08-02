using SammysAuto.Data;
using SammysAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.ViewModel
{
    public class CarAndCustomerViewModel
    {
        public SammysAutoApplicationUser UserObj { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
