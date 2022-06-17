using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.DAL;
using WebUI.Models;
using WebUI.ViewModels.Categories;

namespace WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private AppDbContext _context { get; }
        public IEnumerable<Category> categories { get; set; }
        public CategoryController(AppDbContext context)
        {
            _context = context;
            categories = _context.Category.Where(ct => !ct.IsDeleted);
        }
        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVm category)
        {
            bool isExist = categories.Where(ct => !ct.IsDeleted).Any(ct => ct.Name.ToLower() == category.Name.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", $"{category.Name} is Exist");
                return View();
            }
            //foreach (var ct in categories)
            //{
            //    if (ct.Name==category.Name)
            //    {
            //        isExist = true;
            //    }
            //}

            if (!ModelState.IsValid) return View();
            Category newCategory = new Category
            {
                Name = category.Name
            };
            await _context.Category.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Category category = _context.Category.Where(ct => !ct.IsDeleted).FirstOrDefault(ct => ct.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category categoryDb = _context.Category.Where(ct => !ct.IsDeleted).FirstOrDefault(ct => ct.Id == id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            //if (category.Name.ToLower() == categoryDb.Name.ToLower())
            //{
            //    RedirectToAction(nameof(Index));
            //}

            bool isExist = categories.Where(ct => !ct.IsDeleted)
                .Any(ct => ct.Name.ToLower() == category.Name.ToLower() && ct.Id!=category.Id);
            if (isExist)
            {
                ModelState.AddModelError("Name", $"{category.Name} is Exist");
                return View();
            }

            categoryDb.Name = category.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category categoryDb = _context.Category.Where(ct => !ct.IsDeleted).FirstOrDefault(ct => ct.Id == id);
            if (categoryDb == null)
            {
                return NotFound();
            }

            categoryDb.IsDeleted =true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
