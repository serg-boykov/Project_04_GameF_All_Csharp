using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardF.Tests
{
    /// <summary>
    /// The class of the Unit Tests of the Game F.
    /// </summary>
    [TestClass()]
    public class GameTests
    {
        /// <summary>
        /// The unit test for filling some cells on the board.
        /// </summary>
        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();

            // Цифра 1 должна быть по координатам (0, 0)
            Assert.AreEqual(1, game.GetDigitAt(0, 0));

            // Цифра 2 должна быть по координатам (1, 0)
            Assert.AreEqual(2, game.GetDigitAt(1, 0));

            // Аналогичные операции с цифрами 5, 15, 0 (Пустая клетка)
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(3, 3));
        }

        /// <summary>
        /// The unit test for clicking on some cells to move it.
        /// </summary>
        [TestMethod()]
        public void PressAtTest()
        {
            Game game = new Game(4);
            game.Start();

            // The number 15 is pressed to move.
            game.PressAt(2, 3);

            // Empty cell 0 should be according to the coordinates (2, 3)
            Assert.AreEqual(0, game.GetDigitAt(2, 3));

            // The cell 15 should be according to the coordinates (3, 3)
            Assert.AreEqual(15, game.GetDigitAt(3, 3));


            // Similar operations when pressing the number 11.
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }

        /// <summary>
        /// The unit test for getting the number of the cell.
        /// </summary>
        [TestMethod()]
        public void GetDigitAtTest()
        {
            Game game = new Game(4);
            game.Start();

            // Checking empty cell 0 for
            // NOT correct coordinates (-5, 34) and (15, 6)
            Assert.AreEqual(0, game.GetDigitAt(-5, 34));
            Assert.AreEqual(0, game.GetDigitAt(15, 6));
        }

        /// <summary>
        /// The unit test for the game is over.
        /// </summary>
        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start();

            // When all the numbers are in the right order
            // then there should be true.
            Assert.IsTrue(game.Solved());

            // When pressing the number 15 there should be FALSE.
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());

            // Again pressing the number 15 should already be True.
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}