using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void TestPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameRef(ref Book book, string Name)
        {
            book = new Book(Name);
        }

        [Fact]
        public void TestPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string Name)
        {
            book = new Book(Name);
        }

        [Fact]
        public void TestCanSetName()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book1, string newName)
        {
            book1.Name = newName;
        }

        [Fact]
        public void TestDiffObj()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TestSameRef()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book2, book1);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
