namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System.Collections.Specialized;
    using System.Globalization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetIntegerValueTests
    {
        [TestMethod]
        public void Given_No_Matching_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.GetIntegerValue("key4");

            // Assert
            Assert.AreEqual(default(int), outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.GetIntegerValue("key1");

            // Assert
            Assert.AreEqual(default(int), outcome);
        }

        [TestMethod]
        public void Given_No_Matching_Keys_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "1" }, { "key2", "2" }, { "key3", "3" } };
            var fallback = 42;

            // Act
            var outcome = nvc.GetIntegerValue("key4", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_A_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();
            var fallback = 42;

            // Act
            var outcome = nvc.GetIntegerValue("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_No_Fallback_Should_Return_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "42" } };

            // Act
            var outcome = nvc.GetIntegerValue("key1");

            // Assert
            Assert.AreEqual(42, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Fallback_Should_Return_Found_Value_Not_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "42" } };
            var fallback = 9;

            // Act
            var outcome = nvc.GetIntegerValue("key1", fallback);

            // Assert
            Assert.AreNotEqual(fallback, outcome);
            Assert.AreEqual(42, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Integer_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };

            // Act
            var outcome = nvc.GetIntegerValue("key1");

            // Assert
            Assert.AreEqual(default(int), outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Integer_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var fallback = 42;

            // Act
            var outcome = nvc.GetIntegerValue("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Parsing_Options_Should_Return_Found_Value()
        {
            // Arrange
            var unparsedValue = " 1  ";
            var nvc = new NameValueCollection() { { "key1", unparsedValue } };
            var styles = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
            var formatter = new CultureInfo("en-US");

            // Act
            var outcome = nvc.GetIntegerValue("key1", styles, formatter);
            int.TryParse(unparsedValue, styles, formatter, out var parsedValue);

            // Assert
            Assert.AreEqual(parsedValue, outcome);
            Assert.AreNotEqual(default(int), outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Integer_And_Parsing_Options_Should_Return_Default_Value()
        {
            // Arrange
            var unparsedValue = "  1";
            var nvc = new NameValueCollection() { { "key1", unparsedValue } };
            var styles = NumberStyles.AllowTrailingWhite;
            var formatter = new CultureInfo("en-US");

            // Act
            var outcome = nvc.GetIntegerValue("key1", styles, formatter);
            int.TryParse(unparsedValue, out var parsedValue);

            // Assert
            Assert.AreNotEqual(parsedValue, outcome);
            Assert.AreEqual(default(int), outcome);
        }
    }
}
