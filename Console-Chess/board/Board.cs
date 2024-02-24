namespace board
{
    public class Board
    {
        private readonly Piece?[,] _boardPieces;
        public int Lines { get; private set; }
        public int Columns { get; private set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _boardPieces = new Piece[lines, columns];
        }

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

        public Piece? RemovePiece(Position position)
        {
            Piece? aux = Piece(position);
            if (aux == null) return null;

            aux.ChangePosition();

            _boardPieces[position.Line, position.Column] = null;

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