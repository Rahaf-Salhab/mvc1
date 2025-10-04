using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

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
        public ViewResult Create()
        {
            return View("Create",new Category());
        }
        public IActionResult Store(Category request) {
            if (ModelState.IsValid) {
                 context.Categories.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", request);
        }

        public RedirectToActionResult Delete(int id)
        { 
          var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = context.Categories.Find(category.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                 existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                context.Update(existingCategory);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


    }
}
