using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Demo.Models;

namespace Demo.Controllers
{
    public class ApiCarController : ApiController
    {
        private SampleEntities db = new SampleEntities();

        // GET: api/ApiCar
        public IQueryable<CarMake> GetCarMakes()
        {
            return db.CarMakes;
        }

        // GET: api/ApiCar/5
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult GetCarMake(int id)
        {
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return NotFound();
            }

            return Ok(carMake);
        }

        // PUT: api/ApiCar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarMake(int id, CarMake carMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carMake.ID)
            {
                return BadRequest();
            }

            db.Entry(carMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiCar
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult PostCarMake(CarMake carMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarMakes.Add(carMake);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carMake.ID }, carMake);
        }

        // DELETE: api/ApiCar/5
        [ResponseType(typeof(CarMake))]
        public IHttpActionResult DeleteCarMake(int id)
        {
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return NotFound();
            }

            db.CarMakes.Remove(carMake);
            db.SaveChanges();

            return Ok(carMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarMakeExists(int id)
        {
            return db.CarMakes.Count(e => e.ID == id) > 0;
        }
    }
}