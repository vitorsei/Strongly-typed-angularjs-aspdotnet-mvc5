using System;
using System.Collections.Generic;
using System.Linq;
using HeroicCRM.Web.Core;
using HeroicCRM.Web.Data;
using HeroicCRM.Web.Identity;
using HeroicCRM.Web.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HeroicCRM.Web
{
	public static class SeedData
	{
		public static void Init()
		{
			using (var context = new AppDbContext())
			{
				if (!context.Users.Any())
				{
					var manager = new ApplicationUserManager(new UserStore<User>(context));
					manager.Create(new User
					{
						Email = "vitor.seiji@me.com",
						UserName = "Vitor Seiji",
					}, "Password1");

					manager.Create(new User
					{
						Email = "peter.parker@me.com",
						UserName = "Peter Parker",
					}, "Password1");

					manager.Create(new User
					{
						Email = "John.Snow@me.com",
						UserName = "John Snow",
					}, "Password1");
				}

				if (!context.Customers.Any())
				{
					AddNewCustomers(context);

					AddExistingCustomers(context);

					AddTerminatedCustomers(context);

					context.SaveChanges();
				}
			}
		}

		private static void AddTerminatedCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "Dave Grohl",
				HomeEmail = "dave@gmail.com",
				WorkEmail = "dave@company.com",
				WorkAddress = "123 Arlo Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Seymour Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-90),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(5),
			});

			context.Customers.Add(new Customer
			{
				Name = "Kurt Kobain",
				HomeEmail = "kurt@gmail.com",
				WorkEmail = "kurt@company.com",
				WorkAddress = "123 Porter Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Jakeman Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-75),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(10),
			});

			context.Customers.Add(new Customer
			{
				Name = "Kate Perry",
				HomeEmail = "kate@gmail.com",
				WorkEmail = "kate@company.com",
				WorkAddress = "123 Edwyn Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Perry Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-45),
				TerminationDate = DateTime.Today.ToStartOfMonth().AddDays(15),
			});
		}

		private static void AddExistingCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "Bill Gates",
				HomeEmail = "gates@gmail.com",
				WorkEmail = "gates@company.com",
				WorkAddress = "123 Gosse Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Greene Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-20),
				Products = new List<Product>()
				{
					new Product{Title = "Windows 10 Enterprise Edition", Description = "Windows 10 is your partner in making things happen. Get fast start-ups, a familiar yet expanded Start menu, and great new ways to get stuff done even across multiple devices. You’ll also love the innovative features like an all-new browser built for online action, plus Cortana, the personal digital assistant who helps you across your day."}
				}
			});

			context.Customers.Add(new Customer
			{
				Name = "Jim Carrey",
				HomeEmail = "jim@gmail.com",
				WorkEmail = "jim@company.com",
				WorkAddress = "123 Warwick Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Rye Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-15),
				Wishes = new List<Wish>
				{
					new Wish{Title = "Looking for a new smartphone", Description = "Call me if you are selling a iPhone 6 or a Samsung Galaxy 6 for fair prices."}
				}
			});

			context.Customers.Add(new Customer
			{
				Name = "Tony Hawk",
				HomeEmail = "tony@gmail.com",
				WorkEmail = "tony@company.com",
				WorkAddress = "123 Odell Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Dennel Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(-10),
				Products = new List<Product>
				{
					new Product{Title = "Skateboards", Description = "Huge selection of cheap skateboards for sale skateboard decks, complete skateboards, wheels, trucks, helmets, Online shop skate warehouse and accessories."}
				}
			});
		}

		private static void AddNewCustomers(AppDbContext context)
		{
			context.Customers.Add(new Customer
			{
				Name = "Lady Gaga",
				HomeEmail = "lady@gmail.com",
				WorkEmail = "lady@company.com",
				WorkAddress = "123 Main Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Second Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth()
			});

			context.Customers.Add(new Customer
			{
				Name = "Wayne Rooney",
				HomeEmail = "roy@gmail.com",
				WorkEmail = "roy@company.com",
				WorkAddress = "123 Roy Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Irvine Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(5),
			});

			context.Customers.Add(new Customer
			{
				Name = "Robin Van Persie",
				HomeEmail = "persie@gmail.com",
                WorkEmail = "persie@company.com",
				WorkAddress = "123 Vere Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Roland Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(10),
			});

			context.Customers.Add(new Customer
			{
				Name = "Karim Benzema",
				HomeEmail = "karim@gmail.com",
				WorkEmail = "karim@company.com",
				WorkAddress = "123 Zack Street\r\nSuite B\r\nNew York, NY 55555",
				HomeAddress = "321 Beasley Street\r\nApt 1205\r\nNew York, NY 55555",
				HomePhone = "(555) 123-4555",
				WorkPhone = "(555) 321-5444",
				CreateDate = DateTime.Today.ToStartOfMonth().AddDays(15),
				Wishes = new List<Wish>
				{
					new Wish{Title = "Looking for Fifa 16 for PS4", Description = "I'm interested in any PS4 games. If you are selling them don't hesitate to contact me."}
				},
                Products = new List<Product>{
                    new Product{ Title = "The Last of US", Description = "Award winning game for only U$60,00."},
                    new Product{ Title = "Metal Gear V - The Phantom Pain (XOne)", Description = "Kojima's masterpiece for only U$75,00."},
                }
			});
		}
	}
}