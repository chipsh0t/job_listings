using JobListingsShared.Models;

namespace JobListingsWeb.Models
{
    public class JobViewModel 
    { 
        public JobViewModel(Job job) 
        { 
            Id = job.Id;
            Name = job.Name ?? "";
            Description = job.Description ?? "";
            Category = job.Category ?? "";
            Requirements = job.Requirements ?? "";
            Location = job.Location ?? "";
            MonthlySalary = job.Monthlysalary;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        public float MonthlySalary { get; set; }
    }
}
