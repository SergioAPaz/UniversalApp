using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using UniversalApp.Auth;
using UniversalApp.Models;

namespace UniversalApp.Controllers.Api
{
    //With this line only the domain universalpp will be allowed to consume the rest api. 
    //But important if you use POSTMAN the connection will be allowed because you are using the same domain(universalapp)
    //in short corz will help us prevent access from other domains to our api website but will not restrict access to tools such as postman
    [EnableCors(origins: "http://www.universalapp.com",headers:"*",methods:"*")] 
    public class CT_ProductsController : ApiController
    {
        private StoreDBEntities1 db = new StoreDBEntities1();

        //[JwtAuthentication]//descomentar esta linea para habilitar seguridad proporcionada por jwt
        // GET: api/CT_Products
        public IQueryable<CT_Products> GetCT_Products()
        {
            
            return db.CT_Products;
        }

        // GET: api/CT_Products/5
        [ResponseType(typeof(CT_Products))]
        public IHttpActionResult GetCT_Products(int id)
        {
            CT_Products cT_Products = db.CT_Products.Find(id);
            if (cT_Products == null)
            {
                return NotFound();
            }

            return Ok(cT_Products);
        }

        // PUT: api/CT_Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCT_Products(int id, CT_Products cT_Products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cT_Products.id)
            {
                return BadRequest();
            }

            db.Entry(cT_Products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CT_ProductsExists(id))
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

        // POST: api/CT_Products
        [ResponseType(typeof(CT_Products))]
        public IHttpActionResult PostCT_Products(CT_Products cT_Products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CT_Products.Add(cT_Products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cT_Products.id }, cT_Products);
        }

        // DELETE: api/CT_Products/5
        [ResponseType(typeof(CT_Products))]
        public IHttpActionResult DeleteCT_Products(int id)
        {
            CT_Products cT_Products = db.CT_Products.Find(id);
            if (cT_Products == null)
            {
                return NotFound();
            }

            db.CT_Products.Remove(cT_Products);
            db.SaveChanges();

            return Ok(cT_Products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CT_ProductsExists(int id)
        {
            return db.CT_Products.Count(e => e.id == id) > 0;
        }
    }
}