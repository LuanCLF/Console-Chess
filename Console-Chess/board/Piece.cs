using board.Enum;
using board;

namespace board
{
    public class Piece
    {
        public Board Board { get; protected set; }
        public int NumberOfMovements { get; protected set; }
        public Position? Position { get; private set; }
        public Color Color { get; private set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;

            Position = null;
            NumberOfMovements = 0;
        }

        public void ChangePosition(Position position)
        {
            Position = position;
        }
    }
}