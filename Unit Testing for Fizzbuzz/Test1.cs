using FizzBuzz_Task;

namespace Unit_Testing_for_Fizzbuzz
{
    [TestClass]
    public class FizzBuzzDetectorTests
    {
        private readonly FizzBuzzDetector _detector = new FizzBuzzDetector();

        [TestMethod]
        public void GetOverlappings_ThirdWord_ReturnsFizz()
        {
            // Arrange
            string input = "one two three";

            // Act
            var result = _detector.getOverlappings(input);

            // Assert
            Assert.AreEqual("one two Fizz", result.Result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetOverlappings_FifthWord_ReturnsBuzz()
        {
            // Arrange
            string input = "one two three four five";

            // Act
            var result = _detector.getOverlappings(input);

            // Assert
            Assert.AreEqual("one two Fizz four Buzz", result.Result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetOverlappings_FifteenthWord_ReturnsFizzBuzz()
        {
            // Arrange
            string input = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";

            // Act
            var result = _detector.getOverlappings(input);

            // Assert
            Assert.AreEqual(
                "one two Fizz four Buzz Fizz seven eight Fizz Buzz eleven Fizz thirteen fourteen FizzBuzz",
                result.Result);
            Assert.AreEqual(7, result.Count);
        }

        [TestMethod]
        public void GetOverlappings_LeadingWhitespace_PreservesWhitespace()
        {
            // Arrange
            string input = "  one two three";

            // Act
            var result = _detector.getOverlappings(input);

            // Assert
            Assert.AreEqual("  one two Fizz", result.Result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetOverlappings_LastWordWithoutTrailingSpace_IsProcessed()
        {
            // Arrange
            string input = "one two three four five six";

            // Act
            var result = _detector.getOverlappings(input);

            // Assert
            Assert.AreEqual("one two Fizz four Buzz Fizz", result.Result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetOverlappings_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => _detector.getOverlappings(input));
        }

        [TestMethod]
        public void GetOverlappings_InputLengthLessThanSeven_ThrowsArgumentException()
        {
            // Arrange
            string input = "abc";

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => _detector.getOverlappings(input));
        }
    }
}
