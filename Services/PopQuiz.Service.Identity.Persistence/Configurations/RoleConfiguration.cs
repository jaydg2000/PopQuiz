using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Identity.Domain;

namespace PopQuiz.Service.Identity.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.RoleType)
                .HasConversion(
                    x => x.ToString(),
                    x => (Role.RoleTypes)Enum.Parse(typeof(Role.RoleTypes), x.ToString()));

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
