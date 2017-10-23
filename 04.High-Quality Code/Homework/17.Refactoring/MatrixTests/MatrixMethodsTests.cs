namespace MatrixTests
{
    using GameFifteen;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixMethodsTests
    {
        [TestMethod]
        public void CheckMatrixIsInRange_ShouldReturnTrue()
        {
            //Arrange
            int[,] matrix = new int[4, 4];
            int startRow = 0;
            int startCol = 0;

            //Act
            bool isInRange = Matrix.CheckMatrixIsInRange(matrix, startRow, startCol);

            //Assert
            Assert.AreEqual(true, isInRange);
        }

        [TestMethod]
        public void GivenDirections_ChangeDirection_ShouldChangeDirections()
        {
            //Arrange
            int directionX = 1;
            int directionY = 1;

            //Act
            Matrix.ChangeDirection(ref directionX, ref directionY);

            //Assert
            Assert.AreEqual(directionX, 1);
            Assert.AreEqual(directionY, 0);
        }

        [TestMethod]
        public void SetupMatrix_ShouldReturnNewRotatedMatrix()
        {
            //Arrange
            int[,] matrix = new int[3, 3];
            int value = 1;
            int startRow = 0;
            int startCol = 0;
            int startDirectionX = 1;
            int startDirectionY = 1;

            //Act
            while (true)
            {
                matrix[startRow, startCol] = value;

                if (!Matrix.CheckMatrixIsInRange(matrix, startRow, startCol))
                {
                    break;
                }

                Matrix.RotateMatrix(
                    ref startRow,
                    3,
                    matrix,
                    ref startDirectionX,
                    ref startCol,
                    ref startDirectionY,
                    ref value);
            }

            int[,] expectedMatrix = { { 1, 7, 8 }, { 6, 2, 9 }, { 5, 4, 3 } };

            //Assert
            CollectionAssert.AreEqual(expectedMatrix, matrix);
        }
    }
}