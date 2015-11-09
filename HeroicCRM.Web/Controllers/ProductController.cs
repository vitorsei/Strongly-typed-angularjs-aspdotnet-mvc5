using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Models;

namespace HeroicCRM.Web.Controllers
{
	public class ProductController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public ProductController(AppDbContext context)
		{
			_context = context;
		}

		public ViewResult Index()
		{
			var models = _context.Products.Project().To<ProductViewModel>().ToArray();
			return View(models);
		}

		public JsonResult Add(AddProductForm form)
		{
			var customer = _context.Customers.Include(x => x.Products).Single(x => x.Id == form.CustomerId);

			var product = Mapper.Map<Product>(form);

			customer.Products.Add(product);

			_context.SaveChanges();

			var model = Mapper.Map<CustomerProductViewModel>(product);

			return BetterJson(model);
		}
	}
}