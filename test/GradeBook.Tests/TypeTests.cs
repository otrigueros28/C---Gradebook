using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logmessage);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void writeLogDelPointMethod()
        {
            WriteLogDelegate log = returnMessage;
            log += returnMessage;
            log+= incrementCount;

            var result = log("hello!");
            Assert.Equal(3, count);

        }

        string incrementCount(string message) 
        {
            count++;
            return message;
        }
        string returnMessage(string message) 
        {
            count++;
            return message;
        }

        [Fact]
        public void ValTypesPassByVal()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref  object x)
        {
            x = 42;
        }

        private object GetInt()
        {
            return 3;
        }

        [Fact]
         public void PassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //act

            //assert
           Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book1, string name)
        {
            book1 = new InMemoryBook(name);
        }
         
         
          [Fact]
         public void PassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //act

            //assert
           Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book1, string name)
        {
            book1 = new InMemoryBook(name);
        }



        [Fact]
         public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            SetName((InMemoryBook)book1, "New Name");

            //act

            //assert
           Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void StringBehaviorLikeValType()
        {
            string name = "oscar";
            var upper = MakeUppercase(name);

            Assert.Equal("OSCAR", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
           Assert.Equal("Book 2", book2.Name);
           Assert.Equal("Book 1", book1.Name);
           Assert.NotSame(book1, book2);
        }

     [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
