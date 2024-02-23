using board;
using chess;

namespace Console_Chess
{
    public class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)

            {
                PrintConsoleColorGreen($"{8 - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        PrintConsoleColorYellow("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                    }
                }

                Console.WriteLine();
            }
            PrintConsoleColorGreen("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White) Console.Write(piece);
            else
            {
                PrintConsoleColorDarkRed($"{piece} ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine()!;
            char column = position[0];
            int line = int.Parse(position[1] + "");

            return new ChessPosition(line, column);
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

        public static void PrintConsoleColorGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            ResetConsoleColor();
        }

        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }
    }
}