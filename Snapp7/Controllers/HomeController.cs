using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Generators;
using Snapp.Core.Securities;

namespace Snapp7.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToActionPreserveMethod(actionName:"Index", controllerName:"Admin");
            //return View();
        }

        public IActionResult Test(string id)
        {
            bool result = CheckNationalCode.CheckCode(id);
            return Content(result.ToString());
        }



    }
}
