namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TryGetValuesTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_Should_Return_False_And_Empty_Array()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.TryGetValues("key4", out var values);

            // Assert
            Assert.IsFalse(outcome);
            Assert.IsNotNull(values);
            Assert.IsFalse(values.Any());
        }

        [TestMethod]
        public void Given_No_Keys_Should_Return_False_And_Empty_Array()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.TryGetValues("key1", out var values);

            // Assert
            Assert.IsFalse(outcome);
            Assert.IsNotNull(values);
            Assert.IsFalse(values.Any());
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_Should_Return_True_And_Values()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" }, { "key1", "value2" } };
            var expected = new List<string>() { "value1", "value2" };

            // Act
            var outcome = nvc.TryGetValues("key1", out var values);

            // Assert
            Assert.IsTrue(outcome);
            Assert.AreEqual(expected.Count(), values.Count());

            for (var i = 0; i < expected.Count; i++)
            {
                var valuesItem = values.ElementAt(i);
                var expectedItem = expected.ElementAt(i);

                Assert.AreEqual(expectedItem, valuesItem);
            }
        }
    }
}
