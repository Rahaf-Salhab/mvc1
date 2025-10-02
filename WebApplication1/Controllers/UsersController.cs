using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        public ViewResult GetAll()
        {
            List<string> users = new List<string>()
            {
            "Rahaf", "Aylol" , "Lia"
            };
            return View("Index",users);
        }
        public ViewResult Create()
        {
            return View("Create");
        }
        public ViewResult Details() {
            return View("Details");
        }
        
    }
}
