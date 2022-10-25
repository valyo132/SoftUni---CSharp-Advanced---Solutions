using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int index = 0;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            index = -1;
        }

        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext() => ++index < this.books.Count;

        public void Reset()
        {
        }
    }
}
