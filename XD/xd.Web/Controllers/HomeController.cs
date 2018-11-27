using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xd.Model;

namespace xd.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var entity = new Entity()
            {
                Id = Guid.NewGuid(),
                Name = "test"
            };
            return View("Home.Index", entity);
        }
    }
}