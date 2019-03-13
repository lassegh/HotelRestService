using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class RoomController : ApiController
    {
        private ManageRoom manage = new ManageRoom();

        // GET: api/Guest
        public IEnumerable<Room> Get()
        {
            return manage.GetAllRooms();
        }

        // GET: api/Guest/5
        public IEnumerable<Room> Get(int id)
        {
            return manage.GetRoomsFromHotelId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Room value)
        {
            manage.CreateRoom(value);
        }

        // PUT: api/Guest/5
        public void Put(int hotelID, int roomID, [FromBody]Room value)
        {
            manage.UpdateRoom(value, hotelID, roomID);
        }

        // DELETE: api/Guest/5
        public void Delete(int hotelID, int roomID)
        {
            manage.DeleteRoom(hotelID, roomID);
        }
    }
}