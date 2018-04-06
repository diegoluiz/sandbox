using System;
using System.Linq;

namespace ConsoleApp2
{

    public class Game
    {
        private Map _map;

        public Game(Map map)
        {
            _map = map;
        }

        public Map Tick()
        {
            if (_map.SelectMany(x => x).Count(x => x.IsAlive) < 3)
            {
                _map.SelectMany(x => x).ToList().ForEach(x => x.IsAlive = false);
            }

            var tempMap = new Map(0, 0);
            foreach (var line in _map)
            {
                foreach (var cell in line)
                {
                    var count = 0;
                    if (_map.HasLeft(cell) && _map.Get(cell.Line, cell.Col - 1).IsAlive)
                        count++;

                    if (_map.HasRight(cell) && _map.Get(cell.Line, cell.Col + 1).IsAlive)
                        count++;

                    if (_map.HasUpper(cell) && _map.Get(cell.Line - 1, cell.Col).IsAlive)
                        count++;

                    if (_map.HasBottom(cell) && _map.Get(cell.Line + 1, cell.Col).IsAlive)
                        count++;

                    bool shouldDie = count < 2;
                    var tempCell = new Cell(cell.Line, cell.Col, !shouldDie);
                    tempMap.New(tempCell);
                    //if (shouldDie)
                    //    cell.IsAlive = false;
                }
            }

            _map = tempMap;
            return _map;
        }

        private bool HasLeftNeighbour(Cell cell)
        {
            return true;
        }
    }
}
