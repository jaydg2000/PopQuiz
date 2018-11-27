using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Quiz.Domain.Entities;

namespace PopQuiz.Service.Quiz.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<ProctoredQuiz>
    {
        public void Configure(EntityTypeBuilder<ProctoredQuiz> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(entity => entity.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(500)");  
        }
    }
}
