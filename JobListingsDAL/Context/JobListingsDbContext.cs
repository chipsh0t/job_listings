using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobListingsShared.Models;

namespace JobListingsDAL.Context
{
	public class JobListingsDbContext:DbContext
	{
		public JobListingsDbContext(DbContextOptions<JobListingsDbContext> options) : base(options) { }
		public DbSet<Job> Jobs => Set<Job>();	
	}
}
