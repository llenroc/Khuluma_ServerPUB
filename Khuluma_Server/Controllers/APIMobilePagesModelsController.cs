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
    public class APIMobilePagesModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/APIMobilePagesModels
        public IQueryable<MobilePagesModel> GetMobilePagesModels()
        {
            return db.MobilePagesModels;
        }

        // GET: api/APIMobilePagesModels/5
        [ResponseType(typeof(MobilePagesModel))]
        public IHttpActionResult GetMobilePagesModel(int id)
        {
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            if (mobilePagesModel == null)
            {
                return NotFound();
            }

            return Ok(mobilePagesModel);
        }

        // PUT: api/APIMobilePagesModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMobilePagesModel(int id, MobilePagesModel mobilePagesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobilePagesModel.PageId)
            {
                return BadRequest();
            }

            db.Entry(mobilePagesModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobilePagesModelExists(id))
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

        // POST: api/APIMobilePagesModels
        [ResponseType(typeof(MobilePagesModel))]
        public IHttpActionResult PostMobilePagesModel(MobilePagesModel mobilePagesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MobilePagesModels.Add(mobilePagesModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mobilePagesModel.PageId }, mobilePagesModel);
        }

        // DELETE: api/APIMobilePagesModels/5
        [ResponseType(typeof(MobilePagesModel))]
        public IHttpActionResult DeleteMobilePagesModel(int id)
        {
            MobilePagesModel mobilePagesModel = db.MobilePagesModels.Find(id);
            if (mobilePagesModel == null)
            {
                return NotFound();
            }

            db.MobilePagesModels.Remove(mobilePagesModel);
            db.SaveChanges();

            return Ok(mobilePagesModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MobilePagesModelExists(int id)
        {
            return db.MobilePagesModels.Count(e => e.PageId == id) > 0;
        }
    }
}