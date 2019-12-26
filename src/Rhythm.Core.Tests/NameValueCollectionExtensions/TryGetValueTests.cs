namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Specialized;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TryGetValueTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_Should_Return_False_And_Empty()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.TryGetValue("key4", out var value);

            // Assert
            Assert.IsFalse(outcome);
            Assert.AreEqual(default(string), value);
        }

        [TestMethod]
        public void Given_No_Keys_Should_Return_False_And_Empty()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.TryGetValue("key1", out var value);

            // Assert
            Assert.IsFalse(outcome);
            Assert.AreEqual(default(string), value);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_Should_Return_True_And_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };

            // Act
            var outcome = nvc.TryGetValue("key1", out var value);

            // Assert
            Assert.IsTrue(outcome);
            Assert.AreEqual("value1", value);
        }
    }
}
