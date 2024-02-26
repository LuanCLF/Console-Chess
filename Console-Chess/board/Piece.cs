namespace board
{
    public abstract class Piece
    {
        public Board Board { get; protected set; }
        public int NumberOfMovements { get; protected set; }
        public Position? Position { get; private set; }
        public Color Color { get; private set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;

            Position = null;
            NumberOfMovements = 0;
        }

        public void ChangePosition()
        {
            Position = null;
        }

        public void ChangePosition(Position position)
        {
            Position = position;
        }

        public void IncreaseNumberOfMovements()
        {
            NumberOfMovements++;
        }

        public bool ExistPossibleMoves()
        {
            bool[,] possibleMoves = PossibleMoves();

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (possibleMoves[i, j]) return true;
                }
            }

            return false;
        }

        public abstract bool[,] PossibleMoves();
    }
}