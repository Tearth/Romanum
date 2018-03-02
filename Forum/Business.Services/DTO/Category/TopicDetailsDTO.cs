namespace Business.Services.DTO.Category
{
    public class TopicDetailsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public FeaturedPostDTO FirstPost { get; set; }
        public FeaturedPostDTO LastPost { get; set; }
        public int PostsCount { get; set; }
    }
}
