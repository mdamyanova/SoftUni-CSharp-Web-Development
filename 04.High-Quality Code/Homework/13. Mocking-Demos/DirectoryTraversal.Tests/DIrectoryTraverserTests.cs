using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryTraversal.Tests
{
    using System;
    using System.Linq;

    [TestClass]
    public class DIrectoryTraverserTests
    {
        [TestMethod]
        public void GetChildDirectories_ShouldReturnDirectoryNames()
        {
           //Arrange
           var fakeDirectoryProvider = new FakeDirectoryProviderComplexPaths();
           var traverser = new DirectoryTraverser(string.Empty, fakeDirectoryProvider);

           var expectedDirectories = new string[] { "Assets", "bin" };
          
           //Act
           var childDirectories =  traverser.GetChildDirectories().ToArray();

           //Assert
           CollectionAssert.AreEqual(expectedDirectories, childDirectories);
        }

        [TestMethod]
        public void ChildDirectories_ShouldCorrectlySortPaths()
        {
            //Arrange
            var fakeDirectoryProvider = new FakeDirectoryProviderUnsortedPaths();
            var traverser = new DirectoryTraverser(string.Empty, fakeDirectoryProvider);

            var expectedDirectories = fakeDirectoryProvider.GetDirectories(string.Empty);
         
            Array.Sort(expectedDirectories);

            //Act
            var childDirectories = traverser.GetChildDirectories().ToArray();

            //Assert
            CollectionAssert.AreEqual(expectedDirectories, childDirectories);
        }
    }
}