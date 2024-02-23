using board;

namespace chess
{
    public class ChessMatch
    {
        private Color _currentPlayer;
        private int _turn;
        public bool GameOver { get; private set; }
        public Board Board { get; private set; }

        public ChessMatch()
        {
            _currentPlayer = Color.White;
            _turn = 1;
            Board = new Board(8, 8);
            GameOver = false;
            PlacePieces();
        }

        public void ExecuteMove(Position origin, Position destiny)
        {
            Piece? piece = Board.RemovePiece(origin);
            piece?.IncreaseNumberOfMovements();
            Piece? pieceCaptured = Board.RemovePiece(destiny);

            if (piece != null) Board.PlacePiece(piece, destiny);
        }

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition(1, 'c').ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition(1, 'b').ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition(2, 'd').ToPosition());

            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition(7, 'f').ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition(6, 'h').ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition(5, 'e').ToPosition());
        }
    }
}