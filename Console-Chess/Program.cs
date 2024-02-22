using board;
using board.Enum;
using chess;

namespace Console_Chess
{
    internal class Program
    {
        private static void Main()
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}