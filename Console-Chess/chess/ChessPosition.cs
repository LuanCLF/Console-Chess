using board;

namespace chess
{
    public class ChessPosition
    {
        public int Line { get; private set; }
        public char Column { get; private set; }

        public ChessPosition(int line, char column)
        {
            Line = line;
            Column = char.Parse(column.ToString().ToUpper());
        }

        public Position ToPosition()
        { return new Position(8 - Line, Column - 'A'); }

        public override string ToString()
        {
            return $"Line: {Line} Column: {Column}";
        }
    }
}