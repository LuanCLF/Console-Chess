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

        private bool StopPossibleMove(Position position)
        {
            Piece? piece = Board.Piece(position);

            if (piece != null && piece.Color != Color)
            {
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
                // North
                position.DefineValues(Position.Line - 1, Position.Column);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line - 1, position.Column);
                }

                // Northeast
                position.DefineValues(Position.Line - 1, Position.Column + 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line - 1, position.Column + 1);
                }

                // East
                position.DefineValues(Position.Line, Position.Column + 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line, position.Column + 1);
                }

                // Southeast
                position.DefineValues(Position.Line + 1, Position.Column + 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line + 1, position.Column + 1);
                }

                // South
                position.DefineValues(Position.Line + 1, Position.Column);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line + 1, position.Column);
                }

                //Southwest
                position.DefineValues(Position.Line + 1, Position.Column - 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line + 1, position.Column - 1);
                }

                // West
                position.DefineValues(Position.Line, Position.Column - 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line, position.Column - 1);
                }

                // Northwest
                position.DefineValues(Position.Line - 1, Position.Column - 1);
                while (IncreasePossibleMoves(possibleMoves, position))
                {
                    if (StopPossibleMove(position)) break;
                    position.DefineValues(position.Line - 1, position.Column - 1);
                }
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "K!";
        }
    }
}