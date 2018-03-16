using System.Collections.Generic;
using System.Linq;
using Business.Services.DTO.Section;
using DataAccess.Database;

namespace Business.Services.SectionServices
{
    /// <summary>
    /// Represents a set of methods to manage sections.
    /// </summary>
    public class SectionService : ServiceBase, ISectionService
    {
        private IDatabaseContext _databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionService"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public SectionService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc />
        public IEnumerable<SectionWithCategoriesDTO> GetAllSectionsWithCategories()
        {
            var sectionsQuery = _databaseContext.Sections;
            var sectionsWithCategories = sectionsQuery.Select(section => new SectionWithCategoriesDTO
            {
                Name = section.Name,
                Categories = section.Categories.OrderBy(category => category.Order).Select(category => new CategoryDetailsDTO
                {
                    ID = category.ID,
                    Name = category.Name,
                    Alias = category.Alias,
                    Description = category.Description,
                    Order = category.Order,
                    TopicsCount = category.Topics.Count,

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
