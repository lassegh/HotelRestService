using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class HotelController : ApiController
    {
        private ManageHotel mnHotel = new ManageHotel();

        // GET: api/Guest
        public IEnumerable<Hotel> Get()
        {
            return mnHotel.GetAllHotels();
        }

        // GET: api/Guest/5
        public Hotel Get(int id)
        {
            return mnHotel.GetHotelFromId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Hotel value)
        {
            mnHotel.CreateHotel(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Hotel value)
        {
            mnHotel.UpdateHotel(value, id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            mnHotel.DeleteHotel(id);
        }
    }
}