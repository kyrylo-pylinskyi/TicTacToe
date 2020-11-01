using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Window Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            GameStart();
        }
        #endregion

        #region Private members

        /// <summary>
        /// Holds the current result of cells in the active game
        /// </summary>
        private MarkType[] markResult;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool playerTurn;

        /// <summary>
        /// True if game ended
        /// </summary>
        private bool gameEnded;

        #endregion

        #region Game Start Method

        /// <summary>
        /// Starts new game and clears all fields
        /// </summary>
        private void GameStart()
        {
            // Creates a new blank array of free cells
            markResult = new MarkType[9];

            for (var i = 0; i < markResult.Length; i++)
                markResult[i] = MarkType.Free;

            // Make sure player 1 starts the game
            playerTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Changes background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure game hasn't finished
            gameEnded = false;

        }

        #endregion

        /// <summary>
        /// Event when button is clicked
        /// </summary>
        /// <param name="sender">button clicked</param>
        /// <param name="e">event</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                GameStart();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Don't do anything if the cell already has a value in it
            if (markResult[index] != MarkType.Free)
                return;

            // Set the cell value based on which players turn it is
            markResult[index] = playerTurn ? MarkType.Cross : MarkType.Nought;

            // Set button text to the result
            button.Content = playerTurn ? "X" : "O";

            // Change noughts to green
            if (!playerTurn)
                button.Foreground = Brushes.Red;

            // Toggle the players turn
            playerTurn ^= true;

            // Check for winer
            CheckForWiner();

        }

        private void CheckForWiner()
        {
            #region Horizontal wins
            bool horizontalZero = ((markResult[0] & markResult[1] & markResult[2]) == markResult[0]);
            bool horizontalOne = ((markResult[3] & markResult[4] & markResult[5]) == markResult[3]);
            bool horizontalTwo = ((markResult[6] & markResult[7] & markResult[8]) == markResult[6]);

            if (markResult[0] != MarkType.Free && horizontalZero)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.DarkCyan;
            }
            else if (markResult[3] != MarkType.Free && horizontalOne)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.DarkCyan;
            }
            else if (markResult[6] != MarkType.Free && horizontalTwo)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.DarkCyan;
            }

            #endregion

            #region Vertical wins
            bool verticalZero = ((markResult[0] & markResult[3] & markResult[6]) == markResult[0]);
            bool verticalOne = ((markResult[1] & markResult[4] & markResult[7]) == markResult[1]);
            bool verticalTwo = ((markResult[2] & markResult[5] & markResult[8]) == markResult[2]);

            if (markResult[0] != MarkType.Free && verticalZero)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.DarkCyan;
            }
            else if (markResult[1] != MarkType.Free && verticalOne)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.DarkCyan;
            }
            else if (markResult[2] != MarkType.Free && verticalTwo)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.DarkCyan;
            }
            #endregion

            #region Cross wins
            bool CrossOne = ((markResult[0] & markResult[4] & markResult[8]) == markResult[4]);
            bool CrossTwo = ((markResult[2] & markResult[4] & markResult[6]) == markResult[4]);

            if (markResult[4] != MarkType.Free && CrossOne)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.DarkCyan;
            }
            else if (markResult[4] != MarkType.Free && CrossTwo)
            {
                // Game ends
                gameEnded = true;

                // Highlight wining cells
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.DarkCyan;
            }
            #endregion

            #region No winers
            if (!markResult.Any(cell => cell == MarkType.Free))
            {
                // Game ends
                gameEnded = true;

                // Turn all cells lightCoral
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    // Changes background
                    button.Background = Brushes.DarkCyan;
                });
            }
            #endregion






        }
    }
}
