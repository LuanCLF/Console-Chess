using board;

namespace chess
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}