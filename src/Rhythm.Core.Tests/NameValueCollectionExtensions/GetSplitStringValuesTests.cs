namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Specialized;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhythm.Core.Enums;

    [TestClass]
    public class GetSplitStringValuesTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_And_No_Fallback_Should_Return_Empty_Array()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.GetSplitStringValues("key4");

            // Assert
            Assert.AreEqual(Enumerable.Empty<string>(), outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_No_Fallback_Should_Return_Empty_Array()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.GetSplitStringValues("key1");

            // Assert
            Assert.AreEqual(Enumerable.Empty<string>(), outcome);
        }

        [TestMethod]
        public void Given_No_Matching_Keys_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };
            var fallback = new[] { "fallback1", "fallback2" };

            // Act
            var outcome = nvc.GetSplitStringValues("key4", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_A_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();
            var fallback = new[] { "fallback1", "fallback2" };

            // Act
            var outcome = nvc.GetSplitStringValues("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_No_Fallback_Should_Return_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1,value2,value3" } };
            var expected = new[] { "value1", "value2", "value3"};
            
            // Act
            var values = nvc.GetSplitStringValues("key1");

            // Assert
            Assert.AreEqual(expected.Count(), values.Count());
            for (var i = 0; i < expected.Count(); i++)
            {
                var valuesItem = values.ElementAt(i);
                var expectedItem = expected.ElementAt(i);

                Assert.AreEqual(expectedItem, valuesItem);
            }
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Fallback_Should_Return_Found_Value_Not_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1,value2,value3" } };
            var fallback = new[] { "fallback1", "fallback2" };
            var expected = new[] { "value1", "value2", "value3" };

            // Act
            var values = nvc.GetSplitStringValues("key1", fallback);

            // Assert
            Assert.AreEqual(expected.Count(), values.Count());
            Assert.AreNotEqual(expected.Count(), fallback.Count());
            for (var i = 0; i < expected.Count(); i++)
            {
                var valuesItem = values.ElementAt(i);
                var expectedItem = expected.ElementAt(i);

                Assert.AreEqual(expectedItem, valuesItem);
            }
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_SplitByOption_Should_Return_Correct_Split_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1;value2;value3" } };
            var expected = new[] { "value1", "value2", "value3" };

            // Act
            var values = nvc.GetSplitStringValues("key1", StringSplitDelimiters.Semicolon);

            // Assert
            Assert.AreEqual(expected.Count(), values.Count());
            for (var i = 0; i < expected.Count(); i++)
            {
                var valuesItem = values.ElementAt(i);
                var expectedItem = expected.ElementAt(i);

                Assert.AreEqual(expectedItem, valuesItem);
            }
        }


        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Incorrect_SplitByOption_Should_Return_Incorrect_Split_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1;value2;value3" } };
            var expected = new[] { "value1;value2;value3" };

            // Act
            var values = nvc.GetSplitStringValues("key1", StringSplitDelimiters.Tab);

            // Assert
            Assert.AreEqual(expected.Count(), values.Count());

            for (var i = 0; i < expected.Count(); i++)
            {
                var valuesItem = values.ElementAt(i);
                var expectedItem = expected.ElementAt(i);

                Assert.AreEqual(expectedItem, valuesItem);
            }
        }
    }
}
