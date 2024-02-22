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

        public void PutPiece(Piece piece, Position position)
        {
            _boardPieces[position.Line, position.Column] = piece;
            piece.ChangePosition(position);
        }
    }
}