using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Map _seed = new Map();
        private Game _game;

        [TestMethod]
        public void ProcessTick()
        {
            _game = new Game(_seed);

            var result = _game.Tick();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProcessOneCellDies()
        {
            _seed.Add(new List<bool>() { true });

            _game = new Game(_seed);

            var result = _game.Tick();

            bool allFalse = result.SelectMany(x => x).All(x => !x);
            Assert.IsTrue(allFalse);
        }

        [TestMethod]
        public void ProcessThreeCellsSurvives()
        {
            _seed.Add(new List<bool>() { true, true });
            _seed.Add(new List<bool>() { true, false });

            _game = new Game(_seed);

            var result = _game.Tick();

            var livingCells = result.SelectMany(x => x).Where(x => x).Count();
            Assert.AreEqual(3, livingCells);
        }


        [TestMethod]
        public void ProcessThreeSeparatedCellsDies()
        {
            for (var i = 0; i < new Random().Next(0, 2); i++)
                _seed.Add(new List<bool>() { false, false });

            _seed.Add(new List<bool>() { true, true });
            for (var i = 0; i < new Random().Next(2, 10); i++)
                _seed.Add(new List<bool>() { false, false });
            _seed.Add(new List<bool>() { true, false });

            _game = new Game(_seed);

            var result = _game.Tick();

            bool allFalse = result.SelectMany(x => x).All(x => !x);
            Assert.IsTrue(allFalse);
        }
    }
}
