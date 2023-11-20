using dotnet_3.Data;
using dotnet_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_3.Controllers;
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

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.UAccID == obj.UAccUsername.ToString())
        {
            ModelState.AddModelError("UAccID", "The UAccUsername cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);   
    }

    //GET
    public IActionResult Edit(int? UAccID)
    {
        if(UAccID==null || UAccID == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(UAccID);
       

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.UAccID == obj.UAccUsername.ToString())
        {
            ModelState.AddModelError("UAccID", "The UAccUsername cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? UAccID)
    {
        if (UAccID == null || UAccID == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(UAccID);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? UAccID)
    {
        var obj = _db.Categories.Find(UAccID);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
        
    }
}