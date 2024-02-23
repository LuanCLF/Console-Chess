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
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.GameOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    chessMatch.ExecuteMove(origin, destiny);
                }
            }
            catch (BoardException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}