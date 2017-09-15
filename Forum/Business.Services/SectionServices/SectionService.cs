using Business.Services.DTO.Section;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.SectionServices
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
            var sectionsQuery = _databaseContext.Sections;
            var sectionsWithCategories = sectionsQuery.Select(section => new SectionWithCategoriesDTO()
            {
                Name = section.Name,
                Categories = section.Categories.Select(category => new CategoryDetailsDTO()
                {
                    ID = category.ID,
                    Name = category.Name,
                    Alias = category.Alias,
                    Description = category.Description,
                    TopicsCount = category.Topics.Count(),

                    PostsCount = category.Topics
                        .SelectMany(topic => topic.Posts)
                        .Count(),

                    LastPostCreationTime = category.Topics
                        .SelectMany(topic => topic.Posts)
                        .Select(post => post.CreationTime)
                        .DefaultIfEmpty()
                        .Max()
                })
            }).ToList();

            return sectionsWithCategories;
        }
    }
}
