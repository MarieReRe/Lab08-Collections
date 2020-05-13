using System;
using Xunit;

namespace GenericLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void InitialListEmpty()
        {
            MyGenericList<string> list = new MyGenericList<string>();

            Assert.Equal(object, list.Count);

        }

        [Fact]
        public void CanAddEmptyList()
        {
            MyGenericList<string> list = new MyGenericList<string>();

            list.Add(2);

            Assert.Equal(1, list.Count);
            Assert.Equal(2, list[0]);
        }
    }
}
