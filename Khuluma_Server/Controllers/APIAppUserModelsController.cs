using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Khuluma_Server.Models;
using Khuluma_Server.Models.apiModels;

namespace Khuluma_Server.Controllers
{
    public class APIAppUserModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AppUserAPIModel appUser;

        // GET: api/APIAppUserModels/5
        [ResponseType(typeof(AppUserModel))]
        public IHttpActionResult GetAppUserModel(int id)
        {
            appUser = new AppUserAPIModel();
            AppUserModel appUserModel = db.AppUserModels.Find(id);
            appUser.ID = appUserModel.ID;
            appUser.GroupId = appUserModel.Group.ID;
            appUser.GroupName = appUserModel.Group.GroupName;
            

            if (appUserModel == null)
            {
                return NotFound();
            }

            return Ok(appUser);
        }


        // PUT: api/APIAppUserModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppUserModel(int id, AppUserModel appUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appUserModel.ID)
            {
                return BadRequest();
            }

            db.Entry(appUserModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserModelExists(id))
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

        // POST: api/APIAppUserModels
        [ResponseType(typeof(AppUserModel))]
        public IHttpActionResult PostAppUserModel(AppUserModel appUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppUserModels.Add(appUserModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appUserModel.ID }, appUserModel);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppUserModelExists(int id)
        {
            return db.AppUserModels.Count(e => e.ID == id) > 0;
        }
    }
}