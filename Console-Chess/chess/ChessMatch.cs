using board;

namespace chess
{
    public class ChessMatch

    {
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _captured;

        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }
        public bool GameOver { get; private set; }

        public ChessMatch()
        {
            CurrentPlayer = Color.White;
            Turn = 1;
            Board = new Board(8, 8);
            GameOver = false;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            PlacePieces();
        }

        public void ExecuteMove(Position origin, Position destiny)
        {
            Piece? piece = Board.RemovePiece(origin);
            piece?.IncreaseNumberOfMovements();
            Piece? capturedPiece = Board.RemovePiece(destiny);

            if (piece != null) Board.PlacePiece(piece, destiny);

            if (capturedPiece != null) _captured.Add(capturedPiece);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            ExecuteMove(origin, destiny);
            CurrentPlayer = Color.White;
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            Piece chosenPiece = Board.Piece(position) ?? throw new BoardException("There is no piece at this position!");

            if (chosenPiece.Color != CurrentPlayer) throw new BoardException("The chosen piece is not yours!");

            if (!chosenPiece.ExistPossibleMoves()) throw new BoardException("There are no possible moves for the chosen piece!");
        }

        public void ChangePlayer()
        {
            if (Turn % 2 == 0) CurrentPlayer = Color.Black;
            else CurrentPlayer = Color.White;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = [];
            foreach (Piece capturedPiece in _captured)
            {
                if (capturedPiece.Color == color) aux.Add(capturedPiece);
            }

            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = [];
            foreach (Piece capturedPiece in _pieces)
            {
                if (capturedPiece.Color == color) aux.Add(capturedPiece);
            }

            aux.ExceptWith(CapturedPieces(color));

            return aux;
        }

        public void PlaceNewPiece(Piece piece, int line, char column)
        {
            Board.PlacePiece(piece, new ChessPosition(line, column).ToPosition());
            _pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece(new Rook(Board, Color.White), 1, 'e');
            PlaceNewPiece(new Rook(Board, Color.White), 1, 'a');
            PlaceNewPiece(new King(Board, Color.White), 2, 'a');
            PlaceNewPiece(new Rook(Board, Color.Black), 7, 'f');
            PlaceNewPiece(new Rook(Board, Color.Black), 6, 'h');
            PlaceNewPiece(new King(Board, Color.Black), 5, 'e');
        }
    }
}