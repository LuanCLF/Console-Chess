using board.Enum;
using board;

namespace board
{
    public class Piece
    {
        public Board Board { get; private set; }
        public Position Position { get; private set; }
        public Color Color { get; private set; }
        public int NumberOfMovements { get; protected set; }

        public Piece(Board board, Position position, Color color)
        {
            Board = board;
            Position = position;
            Color = color;
            NumberOfMovements = 0;
        }
    }
}