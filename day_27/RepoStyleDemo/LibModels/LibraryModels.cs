using System.ComponentModel.DataAnnotations.Schema;

namespace LibModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public string Description { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

