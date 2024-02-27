using board;

namespace chess
{
    public class Knight(Board board, Color color) : Piece(board, color)
    {
        private bool CanMove(Position position)
        {
            Piece? piece = Board.Piece(position);

            return piece == null || piece.Color != this.Color;
        }

        private bool IncreasePossibleMoves(bool[,] possibleMoves, Position position)
        {
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                return true;
            }

            return false;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new(0, 0);

            if (Position != null)

            {
                // North && West
                position.DefineValues(Position.Line - 2, Position.Column - 1);
                IncreasePossibleMoves(possibleMoves, position);

                // North && East
                position.DefineValues(Position.Line - 2, Position.Column + 1);
                IncreasePossibleMoves(possibleMoves, position);

                // East && North
                position.DefineValues(Position.Line - 1, Position.Column + 2);
                IncreasePossibleMoves(possibleMoves, position);

                // East && South
                position.DefineValues(Position.Line + 1, Position.Column + 2);
                IncreasePossibleMoves(possibleMoves, position);

                // South && East
                position.DefineValues(Position.Line + 2, Position.Column + 1);
                IncreasePossibleMoves(possibleMoves, position);

                // South && West
                position.DefineValues(Position.Line + 2, Position.Column - 1);
                IncreasePossibleMoves(possibleMoves, position);

                // West && South
                position.DefineValues(Position.Line + 1, Position.Column - 2);
                IncreasePossibleMoves(possibleMoves, position);

                // West && North
                position.DefineValues(Position.Line - 1, Position.Column - 2);
                IncreasePossibleMoves(possibleMoves, position);
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}