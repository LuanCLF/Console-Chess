namespace board
{
    public class Position
    {
        public int Line { get; private set; }
        public int Column { get; private set; }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

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