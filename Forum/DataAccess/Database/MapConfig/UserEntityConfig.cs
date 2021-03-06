﻿using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Database.MapConfig
{
    public class UserEntityConfig : EntityTypeConfiguration<User>
    {
        public UserEntityConfig()
        {
            Property(p => p.Name).HasMaxLength(20).IsRequired();
            Property(p => p.EMail).HasMaxLength(100).IsRequired();
            Property(p => p.JoinTime).IsRequired();

            Property(p => p.City).HasMaxLength(20);
            Property(p => p.About).HasMaxLength(100);
            Property(p => p.Footer).HasMaxLength(100);

            HasOptional(user => user.Avatar)
                .WithMany(avatar => avatar.Users)
                .HasForeignKey(user => user.AvatarID)
                .WillCascadeOnDelete(false);

            HasMany(user => user.Posts)
                .WithRequired(post => post.Author)
                .HasForeignKey(post => post.AuthorID)
                .WillCascadeOnDelete(false);
        }
    }
}
