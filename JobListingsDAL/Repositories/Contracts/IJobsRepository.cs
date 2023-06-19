using JobListingsShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsDAL.Repositories.Contracts
{
	public interface IJobsRepository
	{
		public Task<Job> GetByIdAsync(int id);
		public Task<IQueryable<Job>> ListJobsAsync();
		public Task CreateJob(Job job);
		public Task DeleteJob(int id);	
		public Task EditJob(Job job);
	}
}
