using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerWebAPI.Models;
using ProjectTrackerWebAPI.Models.Common;

namespace ProjectTrackerWebAPI.Data
{
    public class APIDbContext : IdentityDbContext<ApplicationUser>
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppLog> CompLog { get; set; }

        public DbSet<Memo> Memos { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Models.Project> projects { get; set; }
        public DbSet<SubWork> subWorks { get; set; }


        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<ApplicationUser> applicationUser { get; set; }

        //public DbSet<ProjectFile> ProjectFile { get; set; }

        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<ProjectFileHistory> ProjectFileHistory { get; set; }

        public DbSet<Todos> todos { get; set; }

        public DbSet<Receipt> receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FeedBack>()
                .HasOne(f => f.Department)
                .WithMany(d => d.Feedbacks)
                .HasForeignKey(f => f.DepartmentId);

            builder.Entity<Department>()
                .HasOne(d => d.HOD)
                .WithMany(U => U.Departments)
                .HasForeignKey(d => d.HODId);
            builder.Entity<Memo>()
                .HasOne(M => M.Department)
                .WithMany()
                .HasForeignKey(M => M.DepartmentId);
            builder.Entity<Models.Task>()
                .HasOne(T => T.AssignedTo)
                .WithMany(u => u.Tasks)
                .HasForeignKey(T => T.AssignedToId);

            //projectFileHistory
            //builder.Entity<ProjectFileHistory>()
            //    .HasOne(pfh => pfh.File)
            //    .WithMany(pf => pf.ProjectFileHistory)
            //    .HasForeignKey(pfh => pfh.FileId);

            // Configure the relationship between ProjectFileHistory and ApplicationUser
            builder.Entity<ProjectFileHistory>()
                .HasOne(pfh => pfh.AssignedTo)
                .WithMany(U => U.PFilesHistory)
                .HasForeignKey(pfh => pfh.AssignedToId);


            // Configure the index on the ProjectFileHistory entity
            //builder.Entity<ProjectFileHistory>()
            //    .HasIndex(pfh => new { pfh.FileId, pfh.AssignedToId })
            //    .IsUnique();

            //projectFile
            //builder.Entity<ProjectFile>()
            //    .HasOne(pf => pf.Project)
            //    .WithMany(p => p.ProjectFiles)
            //    .HasForeignKey(pf => pf.ProjectId);

            //// Configure the relationship between ProjectFileHistory and ApplicationUser
            //builder.Entity<ProjectFile>()
            //    .HasOne(pf => pf.AssignedTo)
            //    .WithMany(U => U.ProjectFiles)
            //    .HasForeignKey(pf => pf.AssignedToId);


            // Configure the index on the ProjectFileHistory entity
            //builder.Entity<ProjectFile>()
            //    .HasIndex(pf => new { pf.ProjectId, pf.AssignedToId })
            //    .IsUnique();

        }

        public DbSet<ProjectTrackerWebAPI.Models.Department> Department { get; set; }

    }

}
