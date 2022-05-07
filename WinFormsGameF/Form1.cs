using BoardF;
using System;
using System.Windows.Forms;

namespace WinFormsGameF
{
    public partial class FormGame15 : Form
    {
        /// <summary>
        /// The size of the board for the WinForms Game F.
        /// </summary>
        const int size = 4;

        /// <summary>
        /// The WinForms Game F.
        /// </summary>
        readonly Game game;

        /// <summary>
        /// The class constructor.
        /// </summary>
        public FormGame15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        /// <summary>
        /// Event to press the mouse on the cell of the game board.
        /// </summary>
        /// <param name="sender">The cell of the game board.</param>
        /// <param name="e">Event data.</param>
        private void B00_Click(object sender, EventArgs e)
        {
            if (game.Solved())
            {
                return;
            }

            Button button = (Button)sender; // b00

            // The name of the cell like "b00".
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));

            game.PressAt(x, y);
            ShowButton();

            if (game.Solved())
            {
                labelMoves.Text = "Game finished in " + game.Moves.ToString() + " moves";
            }
        }

        /// <summary>
        /// Start the WinForms Game F.
        /// </summary>
        /// <param name="sender">The cell of the game board.</param>
        /// <param name="e">Event data.</param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            game.Start(1000 + DateTime.Now.DayOfYear);
            ShowButton();
        }

        /// <summary>
        /// Hide the cells.
        /// </summary>
        void HideButtons()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    ShowDigitAt(0, x, y);
                }
            }

            labelMoves.Text = "Welcome to Game F";
        }

        /// <summary>
        /// Show the cells.
        /// </summary>
        void ShowButton()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    ShowDigitAt(game.GetDigitAt(x, y), x, y);
                }
            }

            labelMoves.Text = game.Moves.ToString() + " moves";
        }

        /// <summary>
        /// Show the digit at the cell with the coordinates x and y.
        /// </summary>
        /// <param name="digit">The digit at the cell.</param>
        /// <param name="x">The coordinate X.</param>
        /// <param name="y">The coordinate Y.</param>
        private void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y];

            button.Text = DecToHex(digit);
            button.Visible = digit > 0;
        }

        /// <summary>
        /// Convert the Decimal digit to the Hex digit.
        /// </summary>
        /// <param name="digit">The Decimal digit.</param>
        /// <returns>The Hex digit.</returns>
        private string DecToHex(int digit)
        {
            if (digit == 0)
            {
                return "";
            }
            else if (digit < 10)
            {
                return digit.ToString();
            }

            return ((char)('A' + digit - 10)).ToString();
        }
    }
}
