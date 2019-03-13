using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Facility
    {
        public Facility()
        {
            
        }

        public Facility(int hotelId, string facilityName)
        {
            HotelID = hotelId;
            FacilityName = facilityName;
        }

        public int FacilityID { get; set; }
        public int HotelID { get; set; }
        public string FacilityName { get; set; }
    }
}
