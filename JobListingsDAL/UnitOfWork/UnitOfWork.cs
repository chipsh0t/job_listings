using JobListingsDAL.Context;
using JobListingsDAL.Repositories.Contracts;
using JobListingsDAL.UnitOfWork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsDAL.UnitOfWork
{
	public class UnitOfWork:IUnitOfWork
	{
		private JobListingsDbContext _dbContext;
		private IJobsRepository _jobsRepository;

		public UnitOfWork(JobListingsDbContext dbContext, IJobsRepository jobsRepository)
		{
			_dbContext = dbContext;
			_jobsRepository = jobsRepository;
		}

		public IJobsRepository JobsRepository => _jobsRepository;	

		public Task SaveAsync() 
		{ 
			_dbContext.SaveChangesAsync();
			return Task.CompletedTask;
		}
	}
}
