using board;
using Console_Chess.chess;

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

        public bool Check { get; private set; }

        public ChessMatch()
        {
            CurrentPlayer = Color.White;
            Turn = 1;
            Board = new Board(8, 8);
            GameOver = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece? ExecuteMove(Position? origin, Position destiny)
        {
            Piece? piece = Board.RemovePiece(origin);
            piece?.IncreaseNumberOfMovements();
            Piece? capturedPiece = Board.RemovePiece(destiny);

            if (piece != null) Board.PlacePiece(piece, destiny);

            if (capturedPiece != null) _captured.Add(capturedPiece);

            return capturedPiece;
        }

        private void UndoMove(Position? origin, Position destiny, Piece? capturedPiece)
        {
            Piece pieceAtDestiny = Board.RemovePiece(destiny)!;
            pieceAtDestiny.DecreaseNumberOfMovements();

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destiny);
                _captured.Remove(capturedPiece);
            }

            if (origin != null) Board.PlacePiece(pieceAtDestiny, origin);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece? capturedPiece = ExecuteMove(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);

                throw new BoardException("You cannot put yourself in check");
            }

            if (IsInCheck(Opponent(CurrentPlayer))) Check = true;
            else Check = false;

            if (TestCheckMate(Opponent(CurrentPlayer))) GameOver = true;
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            Piece chosenPiece = Board.Piece(position) ?? throw new BoardException("There is no piece at this position!");

            if (chosenPiece.Color != CurrentPlayer) throw new BoardException("The chosen piece is not yours!");

            if (!chosenPiece.ExistPossibleMoves()) throw new BoardException("There are no possible moves for the chosen piece!");
        }

        public void ValidateDestinionPosition(Position origin, Position destiny)
        {
            Piece? piece = Board.Piece(origin);

            if (piece != null && !piece.PossibleMove(destiny)) throw new BoardException("Invalid destination position");
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

        private Color Opponent(Color color)
        {
            if (color == Color.White) return Color.Black;
            else return Color.White;
        }

        private Piece? King(Color color)
        {
            foreach (Piece piece in PiecesInPlay(color))
            {
                if (piece is King) return piece;
            }

            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = King(color) ?? throw new BoardException($"There is no {color} king on the board");
            Position kingPosition = king.Position ?? throw new BoardException($"There is no {color} king in this position");

            foreach (Piece piece in PiecesInPlay(Opponent(color)))
            {
                bool[,] matrix = piece.PossibleMoves();
                if (matrix[kingPosition.Line, kingPosition.Column]) return true;
            }

            return false;
        }

        public bool TestCheckMate(Color color)
        {
            if (!IsInCheck(color)) return false;

            foreach (Piece piece in PiecesInPlay(color))
            {
                bool[,] matrix = piece.PossibleMoves();

                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position destiny = new(i, j);

                            Position? origin = piece.Position;

                            Piece? capturedPiece = ExecuteMove(origin, destiny);

                            bool testCheck = IsInCheck(color);

                            UndoMove(origin, destiny, capturedPiece);

                            if (!testCheck) return false;
                        }
                    }
                }
            }

            return true;
        }

        private void PlaceNewPiece(Piece piece, int line, char column)
        {
            Board.PlacePiece(piece, new ChessPosition(line, column).ToPosition());
            _pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece(new Rook(Board, Color.White), 2, 'f');
            PlaceNewPiece(new Bishop(Board, Color.White), 4, 'd');
            PlaceNewPiece(new Rook(Board, Color.White), 2, 'a');
            PlaceNewPiece(new King(Board, Color.White), 1, 'a');
            PlaceNewPiece(new Rook(Board, Color.Black), 7, 'f');
            PlaceNewPiece(new Rook(Board, Color.Black), 2, 'h');
            PlaceNewPiece(new King(Board, Color.Black), 5, 'e');
        }
    }
}