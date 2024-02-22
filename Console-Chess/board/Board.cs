namespace board
{
    public class Board
    {
        private Piece[,] _boardPieces;
        public int Lines { get; private set; }
        public int Columns { get; private set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _boardPieces = new Piece[lines, columns];
        }

        public Piece Piece(int lines, int columns)
        {
            return _boardPieces[lines, columns];
        }

        public Piece Piece(Position position)
        {
            return _boardPieces[position.Line, position.Column];
        }

        public bool PieceExist(Position position)
        {
            ValidatePosition(position);

            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (PieceExist(position)) throw new BoardException("There is already a piece in this position!");

            _boardPieces[position.Line, position.Column] = piece;
            piece.ChangePosition(position);
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) return false;

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position)) throw new BoardException("Invalid Position!");
        }
    }
}