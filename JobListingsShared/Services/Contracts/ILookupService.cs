using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsShared.Services.Contracts
{
	public interface ILookupService
	{
		public IEnumerable<string> Locations { get; }
		public IEnumerable<string> Categories { get; }
	}
}
