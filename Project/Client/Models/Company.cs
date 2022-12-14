using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    [Table("Company")]
    public class Company
    {
        [DisplayName("Company Id")]
        public string Id { get; set; }

        [DisplayName("Company Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Company Email")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [DisplayName("Company Phone")]
        [StringLength(30)]
        [Required]
        public string Phone { get; set; }

        [DisplayName("Company Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Company Image")]
        public string Image { get; set; }

        [DisplayName("Company Status")]
        [Required]
        public Boolean Status { get; set; }

        [DisplayName("Establishment Date")]
        public DateTime Establishment_date { get; set; }

        [DisplayName("Created Date")]
        public DateTime Created_Date { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
