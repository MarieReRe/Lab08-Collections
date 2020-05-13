using System;
using System.Linq;
using Xunit;

namespace GenericLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void InitialListEmpty()
        {
            GenericLibrary<string> list = new GenericLibrary<string>();

            Assert.Equal(0, list.TotalOfBooks);

        }

        [Fact]
        public void CanAddEmptyList()
        {
            GenericLibrary<int> list = new GenericLibrary<int>();

            list.AddBook(2);
            list.AddBook(10);
            list.AddBook(40);
            list.AddBook(0);

            Assert.Equal(4, list.TotalOfBooks);
            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void CanAddMoreThanCapacity()
        {
            const int Capacity = 1;
            GenericLibrary<int> list = new GenericLibrary<int>(Capacity);
            list.AddBook(2);
            list.AddBook(4);
            list.AddBook(10);


            Assert.Equal(3, list.TotalOfBooks);
            Assert.Equal(2, list[0]);

            list.AddBook(1);

            Assert.Equal(4, list.TotalOfBooks);
            Assert.Equal(1, list[3]);
        }



        
    }
}
