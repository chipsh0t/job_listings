using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListingsBusiness.Services.Contracts;
using JobListingsDAL.UnitOfWork.Contracts;
using JobListingsShared.Models;

namespace JobListingsBusiness.Services
{
	public class JobsService:IJobsService
	{												
		private IUnitOfWork _unitOfWork;
		public JobsService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

		//implementing CRUD functionality in Service
		public async Task<Job> GetJobByIdAsync(int jobid)
		{
			var res = await _unitOfWork.JobsRepository.GetByIdAsync(jobid);
			return res;
		}

		//listig with pagination
		public async Task<(IEnumerable<Job> , int )> ListJobsAsync(int listings_max_amount, int page_number=1) 
		{
			var result = await _unitOfWork.JobsRepository.ListJobsAsync(listings_max_amount,page_number);
			return (result.job_listings_queriable.ToList(), result.total_pages);
		}

		public async Task CreateJobAsync(Job job) 
		{
			await _unitOfWork.JobsRepository.CreateJob(job);
			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteJobAsync(int jobid) 
		{ 
			await _unitOfWork.JobsRepository.DeleteJob(jobid);	
			await _unitOfWork.SaveAsync();
		}

		public async Task EditJobAsync(Job job) 
		{ 
			await _unitOfWork.JobsRepository.EditJob(job);
			await _unitOfWork.SaveAsync();	
		}
	}
}
