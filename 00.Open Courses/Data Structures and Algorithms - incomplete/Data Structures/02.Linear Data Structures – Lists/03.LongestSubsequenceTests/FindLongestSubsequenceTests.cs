using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03.LongestSubsequenceTests
{
    using System.Collections.Generic;

    using _03.LongestSubsequence;

    [TestClass]
    public class FindLongestSubsequenceTests
    {
        [TestMethod]
        public void OneNumber_FindLongestSubsequence_ShouldReturnNumber()
        {
            //Arrange
            var input = new List<int> { 0 };

            //Act
            var result = Program.FindLongestSubsequence(input);
            var expected = new List<int> { 0 };

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DistinctNumbers_FindLongestSubsequence_ShouldReturnLefmostNumber()
        {
            //Arrange
            var input = new List<int> { 1, 2, 3 };

            //Act
            var result = Program.FindLongestSubsequence(input);
            var expected = new List<int> { 1 };

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SeveralNumbers_FindLongestSubsequence_ShouldReturnLongestSubsequence()
        {
            //Arrange
            var input = new List<int> { 1, 2, 3, 4, 4, 5, 5, 5, 7};

            //Act
            var result = Program.FindLongestSubsequence(input);
            var expected = new List<int> { 5, 5, 5 };

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TwoSequences_FindLongestSubsequence_ShouldReturnLefmostSequence()
        {
            //Arrange
            var input = new List<int> { 2, 2, 2, 3, 3, 3 };

            //Act
            var result = Program.FindLongestSubsequence(input);
            var expected = new List<int> { 2, 2, 2 };

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}