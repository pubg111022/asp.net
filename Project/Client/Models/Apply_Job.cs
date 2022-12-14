using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    [Table("Apply_Job")]
    public class Apply_Job
    {
        [DisplayName("Job Id")]
        public string Id { get; set; }

        [DisplayName("User")]
        public String User_Id { get; set; }

        [DisplayName("Job")]
        public String Job_id { get; set; }

        [DisplayName("CV")]
        public String CV { get; set; }

        [DisplayName("Created Date")]
        public DateTime Created_Date { get; set; }

        public Job Job { get; set; }

        public User User { get; set; }
    }
}
