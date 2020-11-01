using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The type of value the sell in the game can curently at
/// </summary>
namespace TicTacToe
{
    public enum MarkType
    {
        /// <summary>
        /// Sell hasn't been clcked yet
        /// </summary>
        Free,

        /// <summary>
        /// Sell is X 
        /// </summary>
        Cross,

        /// <summary>
        /// Sell is O
        /// </summary>
        Nought
    }
}
