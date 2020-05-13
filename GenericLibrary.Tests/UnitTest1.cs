using System;
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

        
    }
}
