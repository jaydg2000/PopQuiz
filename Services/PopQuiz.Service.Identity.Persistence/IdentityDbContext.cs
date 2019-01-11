using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PopQuiz.Service.Identity.Domain;
using PopQuiz.Service.Identity.Persistence.Configurations;

namespace PopQuiz.Service.Identity.Persistence
{
    public class IdentityDbContext : DbContext
    {
        public static readonly LoggerFactory QuizLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.Entity<Role>()
                .HasData(
                new { Id = 1, RoleType = Role.RoleTypes.Guest, Description = "Guest"},
                new { Id = 2, RoleType = Role.RoleTypes.Admin, Description = "Administrator" },
                new { Id = 3, RoleType = Role.RoleTypes.QuizCreator, Description = "Quiz Creator" },
                new { Id = 4, RoleType = Role.RoleTypes.QuizTaker, Description = "Quiz Taker" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // TODO: change to relative path. this is only used for command line tools.
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"D:\Projects\PopQuiz\Services\PopQuiz.Service.Identity\appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder
                .UseLoggerFactory(QuizLoggerFactory)
                .UseSqlServer(config.GetConnectionString("QuizServiceDatabase"));
        }
    }
}
