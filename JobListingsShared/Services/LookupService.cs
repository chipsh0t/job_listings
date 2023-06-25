using JobListingsShared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsShared.Services
{
	public class LookupService:ILookupService
	{
		public IEnumerable<string> Locations => new List<string>{"Tbilisi", "Kutaisi", "Batumi", "Gori", "Zugdidi"};
		public IEnumerable<string> Categories => new List<string>{ "Accounting", "Development", "Technology", "Media and News", "Medical", "Government" };	
	}
}
