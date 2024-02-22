using board;

namespace Console_Chess
{
    internal class Program
    {
        private static void Main()
        {
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);
        }
    }
}