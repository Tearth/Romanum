﻿using Business.Services;
using DataAccess.Database;
using Business.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services.CategoryServices.Exceptions;

namespace Business.Services.CategoryServices
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        IDatabaseContext _databaseContext;

        public CategoryService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public CategoryWithPostsDTO GetCategoryWithPosts(string categoryAlias)
        {
            if (!Exists(categoryAlias))
                throw new CategoryNotFoundException(categoryAlias);

            var categoryWithPosts = _databaseContext
                .Categories.Where(category => category.Alias == categoryAlias)
                .Select(category => new CategoryWithPostsDTO()
                {
                    ID = category.ID,
                    Name = category.Name,
                    Alias = category.Alias,
                    Topics = category.Topics.Select(topic => new TopicDetailsDTO()
                    {
                        ID = topic.ID,
                        Name = topic.Name,
                        Alias = topic.Alias,
                        AuthorName = topic.Posts.OrderByDescending(p => p.CreationTime).FirstOrDefault().User.Name,
                        CreationTime = topic.Posts.OrderByDescending(p => p.CreationTime).FirstOrDefault().CreationTime,
                        PostsCount = topic.Posts.Count,
                        LastPostAuthorName = topic.Posts.OrderBy(p => p.CreationTime).FirstOrDefault().User.Name,
                        LastPostCreationTime = topic.Posts.OrderBy(p => p.CreationTime).FirstOrDefault().CreationTime
                    })
                }).Single();

            return categoryWithPosts;
        }

        public bool Exists(string categoryAlias)
        {
            return _databaseContext.Categories.Any(p => p.Alias == categoryAlias);
        }
    }
}
