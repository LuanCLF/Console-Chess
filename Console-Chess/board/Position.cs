namespace board
{
    public class Position(int line, int column)
    {
        public int Line { get; private set; } = line;
        public int Column { get; private set; } = column;

        public void DefineValues(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"Line: {Line} Column: {Column}";
        }
    }
}