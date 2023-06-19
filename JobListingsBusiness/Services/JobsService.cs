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

		public async Task<IEnumerable<Job>> ListJobsAsync() 
		{
			var res = await _unitOfWork.JobsRepository.ListJobsAsync();
			return res.ToList();
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
