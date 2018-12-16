using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PopQuiz.Service.Quiz.Domain.Entities;
using PopQuiz.Service.Quiz.Persistence.Configurations;

namespace PopQuiz.Service.Quiz.Persistence
{
    public class QuizDbContext : DbContext
    {
        public static readonly LoggerFactory QuizLoggerFactory = new LoggerFactory( new[] { new ConsoleLoggerProvider((_,__) => true, true )});

        public QuizDbContext(): base() { }

        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            :base(options)
        {
        }

        public DbSet<Domain.Entities.Quiz> Quizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // TODO: change to relative path. this is only used for command line tools.
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"D:\Projects\PopQuiz\Services\PopQuiz.Service.Quiz\appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();            
            optionsBuilder
                .UseLoggerFactory(QuizLoggerFactory)
                .UseSqlServer(config.GetConnectionString("QuizServiceDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChoiceConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuizConfiguration());

            modelBuilder.Entity<Question>()
                .HasOne(question => question.Quiz)
                .WithMany(quiz => quiz.Questions)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Choice>()
                .HasOne(choice => choice.Question)
                .WithMany(question => question.Choices)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
