using Blog.Business.Services;
using Blog.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService cs)
        {
            _categoryService = cs;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }
    }
}
