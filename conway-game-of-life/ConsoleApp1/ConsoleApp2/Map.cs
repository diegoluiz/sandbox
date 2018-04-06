using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{

    public class Map : List<List<Cell>>
    {
        public int Lines => this.Count;

        public int Cols => this[0]?.Count ?? 0;

        public Map(int lines, int cols)
        {
            for (int i = 0; i < lines; i++)
            {
                var line = new List<Cell>();
                Add(line);
                for (int j = 0; j < cols; j++)
                {
                    line.Add(new Cell(i, j));
                }
            }
        }

        public void New(Cell cell)
        {
            while (cell.Line > this.Count - 1)
                AppendLine();

            while (cell.Col > this[cell.Line].Count - 1)
                AppendCol();

            this[cell.Line][cell.Col] = cell;
        }

        public bool HasLeft(Cell cell)
        {
            return cell.Col != 0;
        }

        public bool HasRight(Cell cell)
        {
            return cell.Col != this[cell.Line].Count - 1;
        }

        public bool HasUpper(Cell cell)
        {
            return cell.Line != 0;
        }

        public bool HasBottom(Cell cell)
        {
            return cell.Line != Count - 1;
        }

        public Cell Get(int line, int col)
        {
            if (Count > line && this[line].Count > col)
                return this[line][col];

            return null;
        }

        public void AppendLine()
        {
            var length = Count != 0 ? this.Max(x => x.Count) : 0;
            var line = new List<Cell>();
            Add(line);
            var i = Count - 1;

            for (int j = 0; j < length; j++)
                line.Add(new Cell(i, j));

        }

        public void AppendCol()
        {
            for (int i = 0; i < Count; i++)
            {
                var j = this[i].Count;
                this[i].Add(new Cell(i, j));
            }
        }

        public void ShiftLines()
        {
            var length = this.Max(x => x.Count);
            var line = new List<Cell>();
            var i = 0;
            for (int j = 0; j < length; j++)
                line.Add(new Cell(i, j));

            Insert(0, line);
        }

        public void ShiftCols()
        {

            for (int i = 0; i < Count; i++)
            {
                var j = this[i].Count;
                this[i].Insert(0, new Cell(i, j));
            }
        }
    }
}
