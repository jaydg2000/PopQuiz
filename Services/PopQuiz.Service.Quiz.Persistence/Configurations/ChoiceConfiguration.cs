using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Persistence.Configurations
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Text)
                .HasColumnName("ChoiceText")
                .IsRequired()
                .HasColumnType("nvarchar(2000)");

            builder.Property(entity => entity.IsCorrect)
                .HasColumnName("IsCorrect")
                .HasColumnType("bit");

            builder.HasOne(entity => entity.Question)
                .WithMany(question => question.Choices)
                .IsRequired();
        }
    }
}
