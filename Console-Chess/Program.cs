using board;

using chess;

namespace Console_Chess
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(2, 4));

                board.PutPiece(new Rook(board, Color.White), new Position(7, 7));
                board.PutPiece(new Rook(board, Color.White), new Position(6, 4));
                board.PutPiece(new King(board, Color.White), new Position(5, 3));

                Screen.PrintBoard(board);
            }
            catch (BoardException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}