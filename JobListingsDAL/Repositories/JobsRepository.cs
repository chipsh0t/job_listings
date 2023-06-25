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

		public async Task<(IQueryable<Job> job_listings_queriable, int total_pages)> ListJobsAsync(int listings_max_amount, int page_number) 
		{
			int total_pages = (int)Math.Ceiling((decimal)_context.Jobs.Count() / listings_max_amount);
			var job_listings = _context.Jobs.Skip(listings_max_amount * (page_number - 1)).Take(listings_max_amount);
			return (await Task.FromResult(job_listings),total_pages);
		}

		public async Task<Job> GetByIdAsync(int id) 
		{
			return await Task.FromResult(_context.Jobs.First(job => job.Id == id));
		}

		public async Task<IQueryable<Job>> GetByNameAsync(string name) 
		{
			var jobs_list = _context.Jobs
							.Where(job => EF.Functions.Like(job.Name,$"%{name}%"));

			return await Task.FromResult(jobs_list);						
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
