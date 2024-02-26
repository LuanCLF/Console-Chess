using board;

namespace chess
{
    public class ChessPosition(int line, char column)
    {
        public int Line { get; private set; } = line;
        public char Column { get; private set; } = char.Parse(column.ToString().ToUpper());

        public Position ToPosition()
        { return new Position(8 - Line, Column - 'A'); }

        public override string ToString()
        {
            return $"Line: {Line} Column: {Column}";
        }
    }
}