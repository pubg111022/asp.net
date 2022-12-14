using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class RecruitmentManagementContext:DbContext
    {

        public RecruitmentManagementContext(DbContextOptions<RecruitmentManagementContext> options) : base(options)
        {

        }
        public DbSet<Job_Category> Job_Categories { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Apply_Job> Apply_Jobs { get; set; }
    }
}
