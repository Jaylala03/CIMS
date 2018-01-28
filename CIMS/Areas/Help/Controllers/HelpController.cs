using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Areas.Help.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help/Help
        public FileResult Index()
        {
            return File("/Event.pdf", "application/pdf");
        }
    }
}