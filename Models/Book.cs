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
            try {
                ValidateBook(title, author, publicationYear, genre, status);
            } catch (Exception e){
                throw new Exception("Exception: " + e.Message);
            }
            this.id = id;
            this.title = title;
            this.author = author;
            this.publicationYear = publicationYear;
            this.genre = genre;
            this.status = status;
        }

        private bool ValidateBook(string title, string author, int publicationYear, string genre, int status){
            // if (!IsTitleValid(title)) throw new Exception("Valid title is between 0-100 chars");
            // if (!IsPublicationYearValid(publicationYear)) throw new Exception("Publication year can not be in future or some negative number");
            return true;
        }

        private bool IsTitleValid(string title){
            if (title.Length < 0 || title.Length > 100) return false;
            return true;
        }

        private bool IsPublicationYearValid(int year){
            if (year < 0 || new DateOnly().Year > year) return false;
            return true;
        }
    }
}