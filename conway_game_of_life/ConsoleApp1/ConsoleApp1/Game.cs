using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Game
    {
        private Map _seed;

        public Game(Map seed)
        {
            _seed = seed;
        }

        public Map Tick()
        {
            for (int i = 0; i < _seed.Count; i++)
            {
                var line = _seed[i];
                ApplyRulesPerLine(i, line);
            }
            return _seed;
        }

        private void ApplyRulesPerLine(int i, List<bool> line)
        {
            for (int j = 0; j < line.Count; j++)
            {
                int count = CountNeighbours(i, j);

                if (count < 2)
                {
                    _seed[i][j] = false;
                }
            }
        }

        private int CountNeighbours(int i, int j)
        {
            int count = 0;

            var line = _seed[i];
            if (HasNeighbourOnTheRight(j, line))
                count++;

            if (HasNeighbourOnTheLeft(j, line))
                count++;

            if (HasNeighbourBellow(i, j))
                count++;

            if (HasNeighbourAbove(i, j))
                count++;

            return count;
        }

        private static bool HasNeighbourOnTheRight(int j, List<bool> line)
        {
            return j < line.Count && line[j];
        }

        private static bool HasNeighbourOnTheLeft(int j, List<bool> line)
        {
            return j > 0 && line[j - 1];
        }

        private bool HasNeighbourAbove(int i, int j)
        {
            return i > 0 && _seed[i - 1][j];
        }

        private bool HasNeighbourBellow(int i, int j)
        {
            return i + 1 < _seed.Count && _seed[i + 1][j];
        }
    }

    //public class Printer : IPrinter
    //{
    //    public void Print(Map map)
    //    {
    //        foreach (var line in map)
    //        {
    //            foreach (var col in line)
    //            {
    //                System.Console.Write(col? "A" : "D");
    //            }
    //            System.Console.WriteLine();
    //        }
    //    }
    //}

    public class Map : List<List<bool>>
    {

    }
}