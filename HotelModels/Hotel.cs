using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Hotel
    {
        public Hotel()
        {
            
        }

        public Hotel(string name, string address, int stars)
        {
            Name = name;
            Address = address;
            Stars = stars;
        }

        public int HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; }
    }
}
