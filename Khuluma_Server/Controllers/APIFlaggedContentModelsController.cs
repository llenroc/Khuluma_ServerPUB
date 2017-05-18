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
    public class APIFlaggedContentModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIFlaggedContentModels
        public IQueryable<FlaggedContentModel> GetFlaggedContentModels()
        {
            return db.FlaggedContentModels;
        }

        // GET: api/APIFlaggedContentModels/5
        [ResponseType(typeof(FlaggedContentModel))]
        public IHttpActionResult GetFlaggedContentModel(int id)
        {
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            if (flaggedContentModel == null)
            {
                return NotFound();
            }

            return Ok(flaggedContentModel);
        }

        // PUT: api/APIFlaggedContentModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlaggedContentModel(int id, FlaggedContentModel flaggedContentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flaggedContentModel.ID)
            {
                return BadRequest();
            }

            db.Entry(flaggedContentModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlaggedContentModelExists(id))
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

        // POST: api/APIFlaggedContentModels
        [ResponseType(typeof(FlaggedContentModel))]
        public IHttpActionResult PostFlaggedContentModel(FlaggedContentModel flaggedContentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlaggedContentModels.Add(flaggedContentModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flaggedContentModel.ID }, flaggedContentModel);
        }

        // DELETE: api/APIFlaggedContentModels/5
        [ResponseType(typeof(FlaggedContentModel))]
        public IHttpActionResult DeleteFlaggedContentModel(int id)
        {
            FlaggedContentModel flaggedContentModel = db.FlaggedContentModels.Find(id);
            if (flaggedContentModel == null)
            {
                return NotFound();
            }

            db.FlaggedContentModels.Remove(flaggedContentModel);
            db.SaveChanges();

            return Ok(flaggedContentModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlaggedContentModelExists(int id)
        {
            return db.FlaggedContentModels.Count(e => e.ID == id) > 0;
        }
    }
}