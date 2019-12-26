namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Specialized;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetBooleanValueTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.GetBooleanValue("key4");

            // Assert
            Assert.AreEqual(default(bool), outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.GetBooleanValue("key1");

            // Assert
            Assert.AreEqual(default(bool), outcome);
        }

        [TestMethod]
        public void Given_No_Matching_Keys_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "1" }, { "key2", "2" }, { "key3", "3" } };
            var fallback = true;

            // Act
            var outcome = nvc.GetBooleanValue("key4", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_A_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();
            var fallback = true;

            // Act
            var outcome = nvc.GetBooleanValue("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_No_Fallback_Should_Return_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "true" } };

            // Act
            var outcome = nvc.GetBooleanValue("key1");

            // Assert
            Assert.AreEqual(true, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Fallback_Should_Return_Found_Value_Not_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "true" } };
            var fallback = false;

            // Act
            var outcome = nvc.GetBooleanValue("key1", fallback);

            // Assert
            Assert.AreNotEqual(fallback, outcome);
            Assert.AreEqual(true, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Boolean_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };

            // Act
            var outcome = nvc.GetBooleanValue("key1");

            // Assert
            Assert.AreEqual(default(bool), outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Boolean_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var fallback = true;

            // Act
            var outcome = nvc.GetBooleanValue("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }
    }
}
