using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Khuluma_Server.Models;

namespace Khuluma_Server.Controllers
{
    public class APILocationModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APILocationModels
        public IQueryable<LocationModel> GetLocationModels()
        {
            return db.LocationModels;
        }

        // GET: api/APILocationModels/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult GetLocationModel(int id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return Ok(locationModel);
        }

        // PUT: api/APILocationModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocationModel(int id, LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationModel.ID)
            {
                return BadRequest();
            }

            db.Entry(locationModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationModelExists(id))
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

        // POST: api/APILocationModels
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult PostLocationModel(LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LocationModels.Add(locationModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locationModel.ID }, locationModel);
        }

        // DELETE: api/APILocationModels/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult DeleteLocationModel(int id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            db.LocationModels.Remove(locationModel);
            db.SaveChanges();

            return Ok(locationModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationModelExists(int id)
        {
            return db.LocationModels.Count(e => e.ID == id) > 0;
        }
    }
}