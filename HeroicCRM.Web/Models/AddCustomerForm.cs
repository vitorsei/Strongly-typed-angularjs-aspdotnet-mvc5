using Heroic.AutoMapper;
using HeroicCRM.Web.Core;
using System.ComponentModel.DataAnnotations;

namespace HeroicCRM.Web.Models
{
	public class AddCustomerForm : IMapTo<Customer>
	{
		[Display(Name = "Full Name", Prompt="Full Name (ex: John Doe)")]
        public string Name { get; set; }

		public string WorkEmail { get; set; }

		public string HomeEmail { get; set; }

		public string WorkPhone { get; set; }

		public string HomePhone { get; set; }

		[DataType(DataType.MultilineText)]
        public string WorkAddress { get; set; }

        [DataType(DataType.MultilineText)]
        public string HomeAddress { get; set; }
	}
}