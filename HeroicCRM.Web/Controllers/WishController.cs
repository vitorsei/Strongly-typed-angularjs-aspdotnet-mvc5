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
	public class WishController : HeroicCRMControllerBase
	{
		private readonly AppDbContext _context;

		public WishController(AppDbContext context)
		{
			_context = context;
		}

		public ViewResult Index()
		{
			var models = _context.Wishes.Project().To<WishViewModel>().ToArray();
			return View(models);
		}

		public JsonResult Add(AddWishForm form)
		{
			var customer = _context.Customers.Include(x => x.Wishes).Single(x => x.Id == form.CustomerId);

			var wish = Mapper.Map<Wish>(form);

			customer.Wishes.Add(wish);

			_context.SaveChanges();

			var model = Mapper.Map<CustomerWishViewModel>(wish);

			return BetterJson(model);
		}
	}
}