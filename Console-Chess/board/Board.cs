namespace board
{
    public class Board(int lines, int columns)
    {
        private readonly Piece?[,] _boardPieces = new Piece[lines, columns];
        public int Lines { get; private set; } = lines;
        public int Columns { get; private set; } = columns;

        public Piece? Piece(int lines, int columns)
        {
            return _boardPieces[lines, columns];
        }

        public Piece? Piece(Position position)
        {
            Piece? piece = _boardPieces[position.Line, position.Column];
            return piece;
        }

        public bool PieceExist(Position position)
        {
            ValidatePosition(position);

            return _boardPieces[position.Line, position.Column] != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExist(position)) throw new BoardException("There is already a piece in this position!");

            _boardPieces[position.Line, position.Column] = piece;
            piece.ChangePosition(position);
        }

        public Piece? RemovePiece(Position? position)
        {
            Piece? aux = null;

            if (position != null) aux = Piece(position);
            if (aux == null) return null;

            aux.ChangePosition();

            if (position != null) _boardPieces[position.Line, position.Column] = null;

            return aux;
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