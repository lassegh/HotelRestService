using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Room
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public char RoomType { get; set; }
        public double Price { get; set; }
    }
}
