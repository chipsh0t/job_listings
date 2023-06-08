using JobListingsDAL.Context;
using JobListingsDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListingsShared.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobListingsDAL.Repositories
{
	public class JobsRepository:IJobsRepository
	{
		private readonly JobListingsDbContext _context;

		public JobsRepository(JobListingsDbContext context) 
		{ 
			_context = context;
		}

		public async Task<IQueryable<Job>> ListJobsAsync() 
		{
			return await Task.FromResult(_context.Jobs);
		}

		public async Task<Job> GetByIdAsync(int id) 
		{
			return await Task.FromResult(_context.Jobs.First(job => job.Id == id));
		}

		public Task CreateJob(Job job) 
		{ 
			job.Created = DateTime.Now;
			_context.Jobs.Add(job);
			return Task.CompletedTask;	
		}

		public Task DeleteJob(int id) 
		{
			var job_to_remove = new Job { Id = id };
			_context.Jobs.Attach(job_to_remove);
			_context.Jobs.Remove(job_to_remove);
			return Task.CompletedTask;
		}

		public Task EditJob(Job job) 
		{
			//var job_to_change = _context.Jobs.FirstOrDefault(j => j.Id == job.Id);
			//if (job_to_change != null) 
			//{ 
			//	job_to_change.Name = job.Name;
			//	job_to_change.Description = job.Description;
			//	job_to_change.Category = job.Category;	
			//	job_to_change.Requirements = job.Requirements;	
			//	job_to_change.Location = job.Location;
			//	job_to_change.Monthlysalary = job.Monthlysalary;	
			//}
			_context.Jobs.Attach(job);
			_context.Entry(job).State = EntityState.Modified;
			return Task.CompletedTask;
		}
	}
}
