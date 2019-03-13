using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelModels
{
    public class Guest
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
