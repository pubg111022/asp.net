using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    [Table("Job_Category")]
    public class Job_Category
    {
        [DisplayName("Category Id")]
        public string Id { get; set; }

        [DisplayName("Category Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Category Status")]
        public Boolean Status { get; set; }

        [DisplayName("Created Date")]
        public DateTime Created_Date { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
