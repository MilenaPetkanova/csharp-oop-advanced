using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;
    private BookComparator comparator;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, this.comparator);
        this.comparator = new BookComparator();
    }

    public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>();
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext() => ++this.currentIndex < this.books.Count;

        public void Reset() => this.currentIndex = -1;
    }

}

