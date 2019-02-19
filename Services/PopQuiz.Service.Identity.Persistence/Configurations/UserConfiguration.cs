using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Identity.Domain;

namespace PopQuiz.Service.Identity.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Ignore(e => e.Roles);
            builder.Ignore(e => e.Token);
        }
    }
}
