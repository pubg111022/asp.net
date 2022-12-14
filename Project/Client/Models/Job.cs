using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    [Table("Job")]
    public class Job
    {
        [DisplayName("Job Id")]
        public string Id { get; set; }

        [DisplayName("Job Title")]
        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Job Location")]
        [StringLength(50)]
        [Required]
        public string Location { get; set; }

        [DisplayName("Job Department")]
        [StringLength(50)]
        [Required]
        public string Department { get; set; }

        [DisplayName("Apply Quantity")]
        [Required]
        public int Quantity { get; set; }

        [DisplayName("Job Skill Level")]
        [Required]
        public string Skill_Level { get; set; }

        [DisplayName("Job Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Job Offer")]
        [Required]
        public string Offer_Salary { get; set; }

        [DisplayName("Expiration Date")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Job Status")]
        [Required]
        public Boolean Status { get; set; }

        [DisplayName("Created_Date")]
        [Required]
        public DateTime Created_Date { get; set; }

        [DisplayName("Category")]
        [Required]
        public String Category_Id { get; set; }

        [DisplayName("User")]
        [Required]
        public String User_Id { get; set; }

        [DisplayName("Company")]
        [Required]
        public String Company_Id { get; set; }

        public Job_Category Job_Category { get; set; }

        public Company Company { get; set; }

        public User User { get; set; }

        public ICollection<Apply_Job> Apply_Jobs { get; set; }
    }
}
