namespace Rhythm.Core.Tests.NameValueCollectionExtensions
{
    using System;
    using System.Collections.Specialized;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetEnumValueIgnoreCaseTests : GetEnumValueTestsBase
    {
        [TestMethod]
        public void Given_No_Matching_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "value1" }, { "key2", "value2" }, { "key3", "value3" } };

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key4");

            // Assert
            Assert.AreEqual(default(TestEnum), outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1");

            // Assert
            Assert.AreEqual(default(TestEnum), outcome);
        }

        [TestMethod]
        public void Given_No_Matching_Keys_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection { { "key1", "1" }, { "key2", "2" }, { "key3", "3" } };
            var fallback = TestEnum.Option2;

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key4", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_No_Keys_And_A_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection();
            var fallback = TestEnum.Option2;

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_No_Fallback_Should_Return_Found_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "Option2" } };

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1");

            // Assert
            Assert.AreEqual(TestEnum.Option2, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Fallback_Should_Return_Found_Value_Not_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "Option2" } };
            var fallback = TestEnum.Option3;

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1", fallback);

            // Assert
            Assert.AreNotEqual(fallback, outcome);
            Assert.AreEqual(TestEnum.Option2, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Enum_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1");

            // Assert
            Assert.AreEqual(default(TestEnum), outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Enum_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var fallback = TestEnum.Option3;

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Generic_Type_And_No_Fallback_Should_Return_Default_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var type = typeof(NotATestEnum);

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<NotATestEnum>("key1");

            // Assert
            Assert.AreEqual(default(NotATestEnum), outcome);
            Assert.IsInstanceOfType(outcome, type);
            Assert.IsFalse(type.IsEnum);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_With_An_Invalid_Generic_Type_And_Fallback_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var type = typeof(NotATestEnum);
            var fallback = new NotATestEnum();

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<NotATestEnum>("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
            Assert.IsInstanceOfType(outcome, type);
            Assert.IsFalse(type.IsEnum);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Ignore_Case_Should_Return_Found_Value()
        {
            // Arrange
            var unparsedValue = "option3";
            var nvc = new NameValueCollection() { { "key1", unparsedValue } };

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1");
            Enum.TryParse<TestEnum>(unparsedValue, true, out var parsedValue);

            // Assert
            Assert.AreNotEqual(default(TestEnum), outcome);
            Assert.AreEqual(parsedValue, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Invalid_Enum_And_Ignore_Case_Should_Return_Fallback_Value()
        {
            // Arrange
            var nvc = new NameValueCollection() { { "key1", "value1" } };
            var fallback = TestEnum.Option2;

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1", fallback);

            // Assert
            Assert.AreEqual(fallback, outcome);
        }

        [TestMethod]
        public void Given_An_Available_Matching_Key_And_Invalid_Enum_And_Ignore_Case_Should_Return_Correct_Found_Value()
        {
            // Arrange
            var unparsedValue = "option2";
            var nvc = new NameValueCollection() { { "key1", unparsedValue } };

            // Act
            var outcome = nvc.GetEnumValueIgnoreCase<TestEnum>("key1");
            Enum.TryParse<TestEnum>(unparsedValue, out var parsedValue);

            // Assert
            Assert.AreNotEqual(parsedValue, outcome);
            Assert.AreEqual(TestEnum.Option2, outcome);
        }
    }
}
