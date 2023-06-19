using JobListingsShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsBusiness.Services.Contracts
{
	public interface IJobsService
	{
		public Task<Job> GetJobByIdAsync(int id);
		public Task<IEnumerable<Job>> ListJobsAsync();
		public Task CreateJobAsync(Job job);
		public Task DeleteJobAsync(int id);
		public Task EditJobAsync(Job job);
	}
}
