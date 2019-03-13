using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class BookingController : ApiController
    {
        private ManageBooking manage = new ManageBooking();

        // GET: api/Guest
        public IEnumerable<Booking> Get()
        {
            return manage.GetAllBookings();
        }

        // GET: api/Guest/5
        public IEnumerable<Booking> Get(int id)
        {
            return manage.GetBookingsFromHotelId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Booking value)
        {
            manage.CreateBooking(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Booking value)
        {
            manage.UpdateBooking(value, id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            manage.DeleteBooking(id);
        }
    }
}