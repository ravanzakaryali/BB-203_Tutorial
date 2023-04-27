namespace Indexer.Models
{
    internal class Library
    {
        private Book[] _books { get; set; }
        public Library(int bookSize)
        {
            _books = new Book[bookSize];
        }
        public Book this[int index]
        {
            get
            {
                if (_books.Length > index)
                {
                    return _books[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (_books.Length > index)
                {
                    _books[index] = value;
                    return;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
}
