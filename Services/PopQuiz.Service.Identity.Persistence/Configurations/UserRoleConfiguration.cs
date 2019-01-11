using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopQuiz.Service.Identity.Domain;

namespace PopQuiz.Service.Identity.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new
            {
                e.UserId,
                e.RoleId
            });

            builder.HasOne(ur => ur.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                .WithMany(role => role.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
