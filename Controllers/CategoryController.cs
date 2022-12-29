using Coreapp.Data;
using Coreapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coreapp.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }
    
    //Create
        public IActionResult Create()
    {
        return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString()){
            ModelState.AddModelError("name","The DisplayOrder cannot exactly match the Name.");
        }
        if(ModelState.IsValid){
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


        //Edit
            public IActionResult Edit(int? id)
    {
        if (id == null || id == 0){
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        
        if (categoryFromDb == null){
            return NotFound();
        }
        
        return View(categoryFromDb);
        
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString()){
            ModelState.AddModelError("name","The DisplayOrder cannot exactly match the Name.");
        }
        if(ModelState.IsValid){
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

        //Delete
                public IActionResult Delete(int? id)
    {
        if (id == null || id == 0){
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        
        if (categoryFromDb == null){
            return NotFound();
        }
        
        return View(categoryFromDb);
        
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);
        
        if (obj == null){
            return NotFound();
        }

        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");    
    }
}
