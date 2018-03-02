using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Entities.Enums;

namespace Business.Services.Tests.Helpers.Database
{
    public class TestDataInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Avatars
            context.Avatars.AddOrUpdate(new Avatar { ID = 1, Type = AvatarType.InternalImage, Source = "/Content/Avatars/internal_1.png" });
            context.Avatars.AddOrUpdate(new Avatar { ID = 2, Type = AvatarType.Gravatar, Source = "gravatar.com/HASH" });

            //Users
            context.Users.AddOrUpdate(new User { ID = 1, Name = "User 1", EMail = "user1@local.domain", JoinTime = new DateTime(2015, 1, 1), AvatarID = 1 });
            context.Users.AddOrUpdate(new User { ID = 2, Name = "User 2", EMail = "user2@local.domain", JoinTime = new DateTime(2015, 1, 1), AvatarID = 2 });
            context.Users.AddOrUpdate(new User { ID = 3, Name = "User 3", EMail = "user3@local.domain", JoinTime = new DateTime(2016, 1, 1), AvatarID = null });

            //Sections
            context.Sections.AddOrUpdate(new Section { ID = 1, Name = "Section 1", Alias = "sec-1", Description = "Description 1", Order = 1 });
            context.Sections.AddOrUpdate(new Section { ID = 2, Name = "Section 2", Alias = "sec-2", Description = "Description 2", Order = 2 });
            context.Sections.AddOrUpdate(new Section { ID = 3, Name = "Section 3", Alias = "sec-3", Description = "Description 3", Order = 3 });

            //Categories
            context.Categories.AddOrUpdate(new Category { ID = 1, Name = "Category 1", Alias = "cat-1", Description = "Description 1", Order = 1, SectionID = 1 });
            context.Categories.AddOrUpdate(new Category { ID = 2, Name = "Category 2", Alias = "cat-2", Description = "Description 2", Order = 2, SectionID = 1 });
            context.Categories.AddOrUpdate(new Category { ID = 3, Name = "Category 3", Alias = "cat-3", Description = "Description 3", Order = 3, SectionID = 2 });
            context.Categories.AddOrUpdate(new Category { ID = 4, Name = "Category 4", Alias = "cat-4", Description = "Description 4", Order = 4, SectionID = 2 });

            //Topics
            context.Topics.AddOrUpdate(new Topic { ID = 1, Name = "Topic 1", Alias = "top-1", CategoryID = 1 });
            context.Topics.AddOrUpdate(new Topic { ID = 2, Name = "Topic 2", Alias = "top-2", CategoryID = 1 });
            context.Topics.AddOrUpdate(new Topic { ID = 3, Name = "Topic 3", Alias = "top-3", CategoryID = 1 });
            context.Topics.AddOrUpdate(new Topic { ID = 4, Name = "Topic 4", Alias = "top-4", CategoryID = 2 });

            //Posts
            context.Posts.AddOrUpdate(new Post { ID = 1, CreationTime = new DateTime(2015, 1, 1), ModificationTime = new DateTime(2015, 1, 1), Content = "Content 1", TopicID = 1, AuthorID = 2 });
            context.Posts.AddOrUpdate(new Post { ID = 2, CreationTime = new DateTime(2015, 2, 2), ModificationTime = new DateTime(2015, 2, 2), Content = "Content 2", TopicID = 2, AuthorID = 2 });
            context.Posts.AddOrUpdate(new Post { ID = 3, CreationTime = new DateTime(2015, 3, 3), ModificationTime = new DateTime(2015, 3, 3), Content = "Content 3", TopicID = 2, AuthorID = 1 });
            context.Posts.AddOrUpdate(new Post { ID = 4, CreationTime = new DateTime(2015, 4, 4), ModificationTime = new DateTime(2015, 4, 4), Content = "Content 4", TopicID = 2, AuthorID = 1 });
            context.Posts.AddOrUpdate(new Post { ID = 5, CreationTime = new DateTime(2015, 5, 5), ModificationTime = new DateTime(2015, 5, 5), Content = "Content 5", TopicID = 3, AuthorID = 2 });
            context.Posts.AddOrUpdate(new Post { ID = 6, CreationTime = new DateTime(2015, 6, 6), ModificationTime = new DateTime(2015, 6, 6), Content = "Content 6", TopicID = 3, AuthorID = 1 });
            context.Posts.AddOrUpdate(new Post { ID = 7, CreationTime = new DateTime(2015, 7, 7), ModificationTime = new DateTime(2015, 7, 7), Content = "Content 7", TopicID = 4, AuthorID = 2 });
            context.Posts.AddOrUpdate(new Post { ID = 8, CreationTime = new DateTime(2015, 8, 8), ModificationTime = new DateTime(2015, 8, 8), Content = "Content 8", TopicID = 4, AuthorID = 2 });

            //Configs
            context.Configs.AddOrUpdate(new Config { ID = 1, Key = "Key1", Value = "String value" });
            context.Configs.AddOrUpdate(new Config { ID = 2, Key = "Key2", Value = "True" });
            context.Configs.AddOrUpdate(new Config { ID = 3, Key = "Key3", Value = "False" });
            context.Configs.AddOrUpdate(new Config { ID = 4, Key = "Key4", Value = "123" });
            context.Configs.AddOrUpdate(new Config { ID = 5, Key = "Key5", Value = "10,34" });

            base.Seed(context);
        }
    }
}
