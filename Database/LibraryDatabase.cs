using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    class LibraryDatabase {
        private List<Reader> readers;
        private List<Book> books;

        public LibraryDatabase() {
            // Инициализация базы данных с некоторыми начальными значениями
            readers = new List<Reader> {
                new Reader { Id = 1, Name = "Иван", Lastname = "Иванов" },
                new Reader { Id = 2, Name = "Петр", Lastname = "Петров" }
            };

            books = new List<Book> {
                new Book { Article = 1, Title = "Горе от ума", Author = "Александр Сергеевич Грибоедов", YearOfPublication = 2022 },
                new Book { Article = 2, Title = "Убить пересмешника", Author = "Харпер Ли", YearOfPublication = 2021 },
                new Book { Article = 3, Title = "Пойди, поставь сторожа", Author = "Харпер Ли", YearOfPublication = 2019 }
            };
        }

        // Методы для работы с читателями
        public List<Reader> GetReaders() {
            return readers;
        }

        public Reader GetReaderById(int id) {
            return readers.FirstOrDefault(reader => reader.Id == id);
        }

        public void AddReader(Reader reader) {
            reader.Id = readers.Count > 0 ? readers.Max(r => r.Id) + 1 : 1;
            readers.Add(reader);
        }

        public void UpdateReader(Reader reader) {
            var existingReader = GetReaderById(reader.Id);
            if (existingReader != null) {
                existingReader.Name = reader.Name;
                existingReader.Lastname = reader.Lastname;
            }
        }

        public void DeleteReader(int id) {
            var readerToRemove = GetReaderById(id);
            if (readerToRemove != null) {
                readers.Remove(readerToRemove);
            }
        }

        // Методы для работы с книгами
        public List<Book> GetBooks() {
            return books;
        }

        public Book GetBookByArticle(int article) {
            return books.FirstOrDefault(book => book.Article == article);
        }

        public void AddBook(Book book) {
            book.Article = books.Count > 0 ? books.Max(b => b.Article) + 1 : 1;
            books.Add(book);
        }

        public void UpdateBook(Book book) {
            var existingBook = GetBookByArticle(book.Article);
            if (existingBook != null) {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
            }
        }

        public void DeleteBook(int article) {
            var bookToRemove = GetBookByArticle(article);
            if (bookToRemove != null) {
                books.Remove(bookToRemove);
            }
        }
    }
}
