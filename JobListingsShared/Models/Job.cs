using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingsShared.Models
{
    public class Job
    {
        public int Id { get; set; } 

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Requirements { get; set; }

        [Required]
        public string? Location { get; set; }

        [DataType(DataType.Currency)]
        [Range(1.0f, float.MaxValue, ErrorMessage = "Monthly salary has to be positive !")]
        public float Monthlysalary { get; set; }

        public DateTime? Created { get; set; }

    }
}
