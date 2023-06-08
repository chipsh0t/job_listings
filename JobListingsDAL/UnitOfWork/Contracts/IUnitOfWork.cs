using JobListingsDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsDAL.UnitOfWork.Contracts
{
	public interface IUnitOfWork
	{
		public IJobsRepository JobsRepository { get; }
		public Task SaveAsync();
	}
}
