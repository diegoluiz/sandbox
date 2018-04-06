using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ConsoleApp2.Test
{
    [TestClass]
    public class GameTestShould
    {
        private Game _game;
        private Map _map;

        [TestMethod]
        public void Process_Tick()
        {
            _map = new Map(0, 0);
            _game = new Game(_map);
            var r = _game.Tick();

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void Kill_Less_Than_Two_Cells()
        {
            _map = new Map(0, 0);
            _game = new Game(_map);
            var r = _game.Tick();

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void Keep_All_Cells_With_Two_Neighbours()
        {
            _map = new Map(3, 3);
            _map.New(new Cell(0, 0, true));
            _map.New(new Cell(0, 1, true));
            _map.New(new Cell(1, 0, true));
            _map.New(new Cell(1, 1, true));

            _game = new Game(_map);
            var r = _game.Tick();

            Assert.IsTrue(r.Get(0, 0).IsAlive);
            Assert.IsTrue(r.Get(0, 1).IsAlive);
            Assert.IsTrue(r.Get(1, 0).IsAlive);
            Assert.IsTrue(r.Get(1, 1).IsAlive);

            Assert.AreEqual(5, r.SelectMany(x => x).Count(x => !x.IsAlive));
        }

        [TestMethod]
        public void Keep_Only_Cells_With_Two_Neighbours()
        {
            _map = new Map(3, 3);
            _map.New(new Cell(0, 0, true));
            _map.New(new Cell(0, 1, true));
            _map.New(new Cell(1, 0, true));

            _game = new Game(_map);
            var r = _game.Tick();

            Assert.IsTrue(r.Get(0, 0).IsAlive);
            Assert.IsTrue(!r.Get(0, 1).IsAlive);
            Assert.IsTrue(!r.Get(1, 0).IsAlive);
        }

        [TestMethod]
        public void Keep_Only_Cells_With_Two_Neighbours2()
        {
            _map = new Map(3, 3);
            _map.New(new Cell(0, 1, true));
            _map.New(new Cell(1, 0, true));
            _map.New(new Cell(1, 1, true));

            _game = new Game(_map);
            var r = _game.Tick();

            Assert.IsTrue(r.Get(0, 0).IsAlive);
            Assert.IsTrue(!r.Get(0, 1).IsAlive);
            Assert.IsTrue(!r.Get(1, 0).IsAlive);
        }
    }
}
