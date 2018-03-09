using System.Collections.Generic;

namespace Business.Services.DTO.Category
{
    /// <summary>
    /// Represents the category information with the associated list of topics.
    /// </summary>
    public class CategoryWithPostsDTO
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the displayed category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category alias used in URL.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the category order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the list of associated topics.
        /// </summary>
        public IEnumerable<TopicDetailsDTO> Topics { get; set; }
    }
}
