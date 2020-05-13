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

            Assert.Equal(0, list.Count);

        }

        [Fact]
        public void CanAddEmptyList()
        {
            GenericLibrary<int> list = new GenericLibrary<int>();

            list.AddBook(2);

            Assert.Equal(1, list.Count);
            Assert.Equal(2, list[0]);
        }

        
    }
}
