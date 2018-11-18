using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopQuiz.Service.Quiz.Infrastructure.Persistence.Configurations
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
                .HasMaxLength(50);

            builder.Property(entity => entity.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);            
        }
    }
}
