namespace LMS.Models
{
    class Book
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string title;
        public string Title { get { return title; } set { title = value; } }
        private string author;
        public string Author { get { return author; } set { author = value; } }
        private int publicationYear;
        public int PublicationYear { get { return publicationYear; } set { publicationYear = value; } }
        private string genre;
        public string Genre { get { return genre; } set { genre = value; } }
        private int status;
        public int Status { get { return status; } set { status = value; } }

        public Book(int id, string title, string author, int publicationYear, string genre, int status = 0)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.publicationYear = publicationYear;
            this.genre = genre;
            this.status = status;
        }
    }
}