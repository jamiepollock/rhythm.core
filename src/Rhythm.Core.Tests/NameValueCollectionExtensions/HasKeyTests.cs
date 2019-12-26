namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Specialized;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhythm.Core;

    [TestClass]
    public class HasKeyTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_Should_Return_False()
        {
            // Arrange
            var nvm = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvm.HasKey("key4");

            // Assert
            Assert.IsFalse(outcome);
        }

        [TestMethod]
        public void Given_No_Keys_Should_Return_False()
        {
            // Arrange
            var nvm = new NameValueCollection();

            // Act
            var outcome = nvm.HasKey("key1");

            // Assert
            Assert.IsFalse(outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_Should_Return_True()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };

            // Act
            var outcome = nvc.HasKey("key1");

            // Assert
            Assert.IsTrue(outcome);
        }
    }
}

