using Domain.Services.Database;
using Domain.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SectionServices
{
    public class SectionService : ServiceBase, ISectionService
    {
        IDatabaseContext _databaseContext;

        public SectionService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<SectionWithCategoriesDTO> GetAllSetionsWithCategories()
        {
            var sectionsWithCategories = _databaseContext.Sections.Select(section => new SectionWithCategoriesDTO()
            {
                Name = section.Name,
                Categories = section.Categories.Select(category => new CategoryDetailsDTO()
                {
                    Name = category.Name,
                    Description = category.Description,
                    TopicsCount = category.Topics.Count(),
                    PostsCount = category.Topics.SelectMany(topic => topic.Posts).Count(),
                    LastPostTime = category.Topics.SelectMany(topic => topic.Posts).Select(post => post.CreateTime)
                                                                                   .DefaultIfEmpty()
                                                                                   .Max()
                })
            }).ToList();

            return sectionsWithCategories;
        }
    }
}
