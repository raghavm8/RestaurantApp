using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using Api.Repository;

namespace Api.Controllers
{
    public class RestController : ApiController
    {
        RestRepo r = new RestRepo();
        Irep restaurant;

        public RestController() { }
        public RestController(Irep r)
        {
            restaurant = r;
        }

        public List<M_RESTAURANT> GetRestaurants()
        {
            return r.GetAll();
        }

        public IHttpActionResult GetResrtaurantDerails(int id)
        {
            M_RESTAURANT x = r.GetRestaurantDetails(id);

            if (x == null)
                return NotFound();
            else
                return Ok(x);
        }

        public IHttpActionResult PostCustomer(M_RESTAURANT c)
        {
            if (ModelState.IsValid)
            {
                r.createRestaurant(c);
                return Ok();
            }
            else
                return NotFound();
        }

        public void DeleteCustomer(int id)
        {
            r.deleteRestaurant(id);
        }

        public void PutCustomer(M_RESTAURANT c)
        {
            r.updateRestaurant(c);
        }
    }
}
