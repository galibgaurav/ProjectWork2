using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectWork.Web.Models;
using ProjectWork.Data;
using ProjectWork.Entities;

namespace ProjectWork.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/manageContacts")]
    public class ContactInfoSetController : ApiController
    {
        private ProjectWorkContext db = new ProjectWorkContext();

        // GET: api/ContactInfoSet
        public IQueryable<ContactInfo> GetContactInfoSet()
        {
            return db.ContactInfoSet;
        }

        // GET: api/ContactInfoSet/5
        [ResponseType(typeof(ContactInfo))]
        public async Task<IHttpActionResult> GetContactInfo(int id)
        {
            ContactInfo contactInfo = await db.ContactInfoSet.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return Ok(contactInfo);
        }

        // PUT: api/ContactInfoSet/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactInfo(int id, ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(contactInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
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

        // POST: api/manageContacts
        [Route("PostContactInfo")]
        [ResponseType(typeof(ContactInfo))]
        public async Task<IHttpActionResult> PostContactInfo(ContactInfoModel contactInfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.ContactInfoSet.Add(contactInfo);
            //await db.SaveChangesAsync();
            return null;
            //return CreatedAtRoute("DefaultApi", new { id = contactInfo.ID }, contactInfo);
        }

        // DELETE: api/ContactInfoSet/5
        [ResponseType(typeof(ContactInfo))]
        public async Task<IHttpActionResult> DeleteContactInfo(int id)
        {
            //Need to see
            //ContactInfo contactInfo = await db.ContactInfoSet.FindAsync(id);
            ContactInfo contactInfo = await db.ContactInfoSet.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            db.ContactInfoSet.Remove(contactInfo);
            await db.SaveChangesAsync();

            return Ok(contactInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInfoExists(int id)
        {
            return db.ContactInfoSet.Count(e => e.ID == id) > 0;
        }
    }
}