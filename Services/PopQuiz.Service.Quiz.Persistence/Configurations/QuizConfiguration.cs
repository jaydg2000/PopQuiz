using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Quiz.Domain.Entities;

namespace PopQuiz.Service.Quiz.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Domain.Entities.Quiz>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Quiz> builder)
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

            builder.Metadata.FindNavigation(nameof(Domain.Entities.Quiz.Questions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(q => q.Author)
                .WithMany(auth => auth.Quizes)
                .IsRequired();
        }
    }
}
