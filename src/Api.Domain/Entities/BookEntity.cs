namespace Api.Domain.Entities
{
    public class BookEntity : BaseEntity {
        public string Name { get; set; }
        public string Price { get; set; }
        public SpecificationsEntity Specifications { get; set; }
    }

    public class SpecificationsEntity
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public string PageCount { get; set; }
        public string Illustrator { get; set; }
        public string Genres { get; set; }
    }
}
