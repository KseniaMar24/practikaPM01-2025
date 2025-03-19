using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http;
using System.Web.Mvc;
using WebAppKS.Models;
using WebApplication1.Models;

namespace WebAppKS.Controllers
{
    public class ProductsController : ApiController
    {
        private СкладEntities db = new СкладEntities();
       
        // GET: api/товары
        [ResponseType(typeof(List<Response_Products>))]

        public IHttpActionResult GetGoods()
        {
            return Ok(db.Товары.ToList().ConvertAll(p => new Response_Products(p)));
        }

        [ResponseType(typeof(List<Response_Products>))]
        public IHttpActionResult PostGoods([FromBody] Товары товар)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Товары.Add(товар);
            db.SaveChanges();
            var response = new Response_Products(товар);
            return CreatedAtRoute("DefaultApi", new { id = товар.ID_товара }, response);
        }
    }
}