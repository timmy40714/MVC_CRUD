using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Data;
using MVC_CRUD.Models;
using System.Net.Http;

namespace MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly CallAPIHelper _callAPIHelper;
        private readonly IConfiguration _config;
        public CategoryController(ApplicationDbContext db, CallAPIHelper callAPIHelper, IConfiguration config)
        {
            _db = db;
            _callAPIHelper = callAPIHelper;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var apiUrl = "http://localhost:5000/category";
            var categories = await _callAPIHelper.GetCategoriesFromApi(apiUrl);
            categories = categories.OrderBy(x => x.DisplayOrder).ToList();
            return View(categories);

            //List<Category> objList = _db.Categories.ToList();
            //return View(objList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }
            var apiUrl = "http://localhost:5000/category/Create";
            var result = await _callAPIHelper.CreateCategoryFromApi(apiUrl, obj);
            if (result)
            {
                ViewData["SuccessMessage"] = "新增成功";
                ModelState.Clear();
                return View();
                //return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "新增失敗";
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var apiUrl = $"http://localhost:5000/category/Update/{id}";
            var categories = await _callAPIHelper.GetCategoryFromApi(apiUrl);
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateData(Category obj)
        {
            var apiUrl = $"http://localhost:5000/category/Update/{obj.Id}";
            var result = await _callAPIHelper.UpdateCategoryFromApi(apiUrl, obj);
            if (result)
            {
                ViewData["SuccessMessage"] = "編輯成功";
                return View("Update");
            }
            else
            {
                ViewData["ErrorMessage"] = "編輯失敗";
                return View("Update", obj); // 返回编辑页面，继续编辑
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var apiUrl = $"http://localhost:5000/category/Delete/{id}";
            var categories = await _callAPIHelper.DeleteCategoryFromApi(apiUrl);
            return RedirectToAction("Index");
        }
    }
}
