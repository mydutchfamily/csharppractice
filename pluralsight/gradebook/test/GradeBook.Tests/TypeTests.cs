using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void DelegateCanPointToMetod()
        {
            WriteLogDelegate logDelegate = new WriteLogDelegate(ReturnMessage);
            logDelegate+=ReturnMessage;
            logDelegate+=IncrementCount;

            var result = logDelegate("Hello!");

            Assert.Equal("hello!", result);
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void StringTypes()
        {

            string name = "Scott";
            var uppername = MakeUpper(name);

            Assert.Equal("SCOTT", uppername);
        }

        private string MakeUpper(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);

        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void TestPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameRef(ref InMemoryBook book, string Name)
        {
            book = new InMemoryBook(Name);
        }

        [Fact]
        public void TestPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string Name)
        {
            book = new InMemoryBook(Name);
        }

        [Fact]
        public void TestCanSetName()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book1, string newName)
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

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
