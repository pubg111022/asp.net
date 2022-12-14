using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    [Table("User")]
    public class User
    {
        [DisplayName("User Id")]
        public string Id { get; set; }

        [DisplayName("Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("User Email")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [DisplayName("User Phone")]
        [StringLength(30)]
        [Required]
        public string Phone { get; set; }

        [DisplayName("User Name")]
        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [DisplayName("User Password")]
        [Required]
        public string Password { get; set; }

        [DisplayName("User Gender")]
        [Required]
        public Boolean Gender { get; set; }

        [DisplayName("User Role")]
        public int Role { get; set; }

        [DisplayName("User Avatar")]
        public string Image { get; set; }

        [DisplayName("Company Status")]
        public Boolean Status { get; set; }

        [DisplayName("User Birthday")]
        public DateTime Birthday { get; set; }

        [DisplayName("Created Date")]
        public DateTime Created_Date { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Apply_Job> Apply_Job { get; set; }
    }
}
