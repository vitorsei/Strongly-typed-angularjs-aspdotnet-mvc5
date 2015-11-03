using Heroic.AutoMapper;
using HeroicCRM.Web.Core;

namespace HeroicCRM.Web.Models
{
	public class AddOpportunityForm : IMapTo<Opportunity>
	{
		public int CustomerId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
	}
}