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
		public Task<(IEnumerable<Job>jobs_list,int total_pages)> ListJobsAsync(int listings_max_amount, int page_number);
		public Task CreateJobAsync(Job job);
		public Task DeleteJobAsync(int id);
		public Task EditJobAsync(Job job);
	}
}
