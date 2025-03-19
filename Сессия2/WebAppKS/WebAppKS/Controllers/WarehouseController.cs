using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Http;
using System.Web.Mvc;
using WebAppKS.Models;

namespace WebAppKS.Controllers
{
    public class WarehouseController : ApiController
    {
        private СкладEntities db = new СкладEntities();
       
        // GET: Warehouse
        [ResponseType(typeof(List<Response_Warehouse>))]

        public IHttpActionResult GetWarehouse()
        {
            return Ok(db.Склады.ToList().ConvertAll(p => new Response_Warehouse(p)));
        }
    }
}