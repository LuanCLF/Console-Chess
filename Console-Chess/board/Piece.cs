namespace board
{
    public abstract class Piece(Board board, Color color)
    {
        public Board Board { get; protected set; } = board;
        public int NumberOfMovements { get; protected set; } = 0;
        public Position? Position { get; private set; } = null;
        public Color Color { get; private set; } = color;

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

        public void DecreaseNumberOfMovements()
        {
            NumberOfMovements--;
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