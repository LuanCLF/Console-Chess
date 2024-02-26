using board;
using chess;

namespace Console_Chess
{
    public class Screen
    {
        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.Board);

            Console.WriteLine();
            PrintCapturedPieces(chessMatch);

            PrintConsoleColorDarkMagenta();

            Console.Write($"Turn: ");
            PrintConsoleColorGreen($"{chessMatch.Turn}");
            Console.WriteLine();

            PrintConsoleColorDarkMagenta();

            Console.Write($"Waiting for move: ");
            if (chessMatch.CurrentPlayer == Color.White) PrintConsoleColorOriginal($"{chessMatch.CurrentPlayer}");
            else PrintConsoleColorDarkRed($"{chessMatch.CurrentPlayer}");

            Console.WriteLine();
            if (chessMatch.Check) PrintConsoleColorGreen("CHECK");

            PrintConsoleColorDarkMagenta();

            Console.WriteLine();
        }

        private static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            PrintConsoleColorDarkMagenta();

            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(chessMatch.CapturedPieces(Color.White));

            Console.WriteLine();

            Console.Write("Black: ");
            PrintSet(chessMatch.CapturedPieces(Color.Black));

            Console.WriteLine();
        }

        private static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                if (x.Color == Color.White) PrintConsoleColorOriginal($"{x} ");
                else PrintConsoleColorDarkRed($"{x} ");
            }
            PrintConsoleColorDarkMagenta();
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)

            {
                PrintConsoleColorGreen($"{8 - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }

                Console.WriteLine();
            }
            PrintConsoleColorGreen("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)

            {
                PrintConsoleColorGreen($"{8 - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j]) Console.BackgroundColor = changedBackground;
                    else Console.BackgroundColor = originalBackground;

                    PrintPiece(board.Piece(i, j));
                }

                Console.WriteLine();
            }
            PrintConsoleColorGreen("  A B C D E F G H");
            Console.BackgroundColor = originalBackground;
            PrintConsoleColorDarkMagenta();
        }

        public static ChessPosition ReadChessPosition()
        {
            PrintConsoleColorGreen();

            string position = Console.ReadLine()!;
            char column = position[0];
            int line = int.Parse(position[1] + "");

            PrintConsoleColorDarkMagenta();

            return new ChessPosition(line, column);
        }

        public static void PrintPiece(Piece? piece)
        {
            if (piece == null) PrintConsoleColorYellow("- ");
            else if (piece.Color == Color.White) Console.Write($"{piece} ");
            else PrintConsoleColorDarkRed($"{piece} ");
        }

        public static void PrintConsoleColorOriginal(string message)
        {
            ResetConsoleColor();
            Console.Write(message);
        }

        public static void PrintConsoleColorDarkMagenta()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        public static void PrintConsoleColorGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void PrintConsoleColorGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            ResetConsoleColor();
        }

        public static void PrintConsoleColorDarkMagenta(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(message);
            ResetConsoleColor();
        }

        public static void PrintConsoleColorDarkRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(message);
            ResetConsoleColor();
        }

        public static void PrintConsoleColorYellow(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            ResetConsoleColor();
        }

        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }
    }
}