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

            Assert.Equal(0, list.Count);

        }

        [Fact]
        public void CanAddEmptyList()
        {
            GenericLibrary<int> list = new GenericLibrary<int>();

            list.Add(2);
            list.Add(10);
            list.Add(40);
            list.Add(0);

            Assert.Equal(4, list.Count);
            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void CanAddMoreThanCapacity()
        {
            const int Capacity = 1;
            GenericLibrary<int> list = new GenericLibrary<int>(Capacity);
            list.Add(2);
            list.Add(4);
            list.Add(10);


            Assert.Equal(3, list.Count);
            Assert.Equal(2, list[0]);

            list.Add(1);

            Assert.Equal(4, list.Count);
            Assert.Equal(1, list[3]);
        }

        [Fact]
        public void EnumerateList()
        {
            GenericLibrary<string> list = new GenericLibrary<string>
            {
                "Name of the Wind",
                "Nopi",
                "The Way of Kings",
                "The Italian Teacher",

            };

            foreach (string item in list)
            {
                Assert.NotNull(item);
            }

            Assert.Equal(
                new[] { "Name of the Wind", "Nopi", "The Way of Kings", "The Italian Teacher" },
                list);
        }

        [Fact]
        public void CanRemoveBook()
        {
            GenericLibrary<string> list = new GenericLibrary<string>
            {
                "The Way of Kings",
                "Nopi",
                "Name of the Wind",
                "The Italian Teacher"
            };

            Assert.True(list.Remove("Nopi"));
            
        }

        
    }
}
