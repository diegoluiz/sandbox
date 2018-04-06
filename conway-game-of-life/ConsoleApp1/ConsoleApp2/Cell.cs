namespace ConsoleApp2
{

    public class Cell
    {
        public bool IsAlive { get; set; }
        public int Line { get; }
        public int Col { get; }

        public Cell(int line, int col, bool isAlive = false)
        {
            Line = line;
            Col = col;
            IsAlive = isAlive;
        }
    }
}
