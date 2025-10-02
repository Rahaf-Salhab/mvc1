using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        /*اتصال مع الداتابيس لجلب البيانات*/
         ApplicationDbContext context = new ApplicationDbContext();
       public ViewResult Index()
        {
            /*احضار الداتا*/
            var categories = context.Categories.ToList();
            /*ارسالها ك model الى view لعرضها */
            return View("Index",categories);
        }

        /*عرض details كل category */
          public ViewResult Details(int id)
        {
            /*find نستخدم لجلب id من الداتابيس*/
            var category = context.Categories.Find(id);
            return View("Details", category);
        }
    }
}
