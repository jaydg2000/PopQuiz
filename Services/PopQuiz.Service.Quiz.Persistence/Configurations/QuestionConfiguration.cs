using Microsoft.EntityFrameworkCore;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Text)
                .HasColumnName("QuestionText")
                .IsRequired()
                .HasColumnType("nvarchar(2000)");
        }
    }
}
