using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class FacilityController : ApiController
    {
        private ManageFacility manage = new ManageFacility();

        // GET: api/Guest
        public IEnumerable<Facility> Get()
        {
            return manage.GetAllFacilities();
        }

        // GET: api/Guest/5
        public IEnumerable<Facility> Get(int id)
        {
            return manage.GetFacilitiesFromHotelId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Facility value)
        {
            manage.CreateFacility(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Facility value)
        {
            manage.UpdateFacility(value, id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            manage.DeleteFacility(id);
        }
    }
}