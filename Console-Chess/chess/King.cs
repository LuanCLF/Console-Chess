using board;

namespace chess
{
    public class King(Board board, Color color) : Piece(board, color)
    {
        private bool CanMove(Position position)
        {
            Piece? piece = Board.Piece(position);

            return piece == null || piece.Color != this.Color;
        }

        private void IncreasePossibleMoves(bool[,] possibleMoves, Position position)
        {
            if (Board.ValidPosition(position) && CanMove(position)) possibleMoves[position.Line, position.Column] = true;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new(0, 0);

            // North
            position.DefineValues(Position!.Line - 1, Position!.Column);
            IncreasePossibleMoves(possibleMoves, position);

            // Northeast
            position.DefineValues(Position!.Line - 1, Position!.Column + 1);
            IncreasePossibleMoves(possibleMoves, position);

            // East
            position.DefineValues(Position!.Line, Position!.Column + 1);
            IncreasePossibleMoves(possibleMoves, position);

            // Southeast
            position.DefineValues(Position!.Line + 1, Position!.Column + 1);
            IncreasePossibleMoves(possibleMoves, position);

            // South
            position.DefineValues(Position!.Line + 1, Position!.Column);
            IncreasePossibleMoves(possibleMoves, position);

            //Southwest
            position.DefineValues(Position!.Line + 1, Position!.Column - 1);
            IncreasePossibleMoves(possibleMoves, position);

            // West
            position.DefineValues(Position!.Line, Position!.Column - 1);
            IncreasePossibleMoves(possibleMoves, position);

            // Northwest
            position.DefineValues(Position!.Line - 1, Position!.Column - 1);
            IncreasePossibleMoves(possibleMoves, position);

            return possibleMoves;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}