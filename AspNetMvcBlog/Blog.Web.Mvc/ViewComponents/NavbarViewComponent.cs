using Blog.Data;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.ViewComponents;

public class NavbarViewComponent : ViewComponent
{
	private readonly AppDbContext db;

	public NavbarViewComponent(AppDbContext Db)
	{
		db = Db;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		//AppDbContext Db;
		//db = Db;
		
		return View(
			new NavbarDto
			{
				categories= db.Categories.ToList(),
				pages= db.Pages.ToList(),
			}
			);
		//return View();
	}
}
