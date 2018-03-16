using System;

namespace Business.Services.DTO.Section
{
    /// <summary>
    /// Represents the category information.
    /// </summary>
    public class CategoryDetailsDTO
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the topics count which are stored in the category.
        /// </summary>
        public int TopicsCount { get; set; }

        /// <summary>
        /// Gets or sets the posts count which are stored in the category.
        /// </summary>
        public int PostsCount { get; set; }

        /// <summary>
        /// Gets or sets the date of the last post in the category.
        /// </summary>
        public DateTime LastPostCreationTime { get; set; }
    }
}
