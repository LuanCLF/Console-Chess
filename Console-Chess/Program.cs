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
                ChessMatch chessMatch = new();

                while (!chessMatch.GameOver)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(chessMatch);

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateOriginPosition(origin);
                        bool[,] possibleMoves = chessMatch.Board.Piece(origin)!.PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.Board, possibleMoves);
                        Console.WriteLine();

                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();

                        chessMatch.MakeMove(origin, destiny);
                        Console.Clear();
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}