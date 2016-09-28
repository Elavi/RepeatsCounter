using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WordsCounter;

namespace WordsCounterTests
{
    [TestClass]
    public class StringPreparatorTests
    {
        [TestMethod]
        public void CheckMakeLower()
        {
            //Arrange
            var prepatator = new StringPreparator();
            var input = "Example String";

            //Act
            var result = prepatator.MakeLower(input);

            //Assert
            Assert.AreEqual(result, "example string");
        }

        [TestMethod]
        public void CheckTrim()
        {
            //Arrange
            var prepatator = new StringPreparator();
            var input = "   example string   ";

            //Act
            var result = prepatator.Trim(input);

            //Assert
            Assert.AreEqual(result, "example string");
        }

        [TestMethod]
        public void CheckRemoveSpecialChars()
        {
            //Arrange
            var prepatator = new StringPreparator();
            var input = "example,- string.";

            //Act
            var result = prepatator.RemoveSpecialChars(input);

            //Assert
            Assert.AreEqual(result, "example string");
        }

        [TestMethod]
        public void CheckCalculateWordsCount()
        {
            //Arrange
            var prepatator = new StringPreparator();
            var input = "Example text, another example text.";

            //Act
            var result = prepatator.CalculateWordsCount(input);

            //Assert
            Assert.AreEqual(result["example"], 2);
            Assert.AreEqual(result["text"], 2);
        }

        [TestMethod]
        public void CheckSortByCount()
        {
            //Arrange
            var prepatator = new StringPreparator();
            var input = new Dictionary<string, int>();
            input.Add("example", 1);
            input.Add("text", 2);
            input.Add("some", 3);

            //Act
            var result = prepatator.SortByCount(input);

            //Assert
            Assert.AreEqual(result.ElementAt(0).Key, "some");
            Assert.AreEqual(result.ElementAt(2).Value, 1);
            Assert.AreNotEqual(result.ElementAt(0).Key, "example");
        }
    }
}
