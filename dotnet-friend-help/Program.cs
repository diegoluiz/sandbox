using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_friend_help
{
    public abstract class BasePart
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public abstract bool IsSimple { get; }
    }

    public class SimplePart : BasePart
    {
        public override bool IsSimple => true;
    }

    public class CompoundPart : BasePart
    {
        public override bool IsSimple => false;

        public List<Tuple<BasePart, int>> Parts { get; set; } = new List<Tuple<BasePart, int>>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var file = @"./input.txt";

            var partsList = new Dictionary<string, BasePart>();

            using (var fileStream = new StreamReader(file))
            {
                string line;
                line = fileStream.ReadLine();
                var simplePartCount = int.Parse(line);

                for (var i = 0; i < simplePartCount; i++)
                {
                    var simplePartInfo = fileStream.ReadLine().Split(" ");
                    var simplePart = new SimplePart
                    {
                        Name = simplePartInfo[0],
                        Value = int.Parse(simplePartInfo[1])
                    };
                    partsList.Add(simplePart.Name, simplePart);
                }

                while ((line = fileStream.ReadLine()) != null)
                {
                    var compoundPartInfo = line.Split(" ");
                    var name = compoundPartInfo[0];
                    var simplePartName = compoundPartInfo[1];
                    var count = int.Parse(compoundPartInfo[2]);

                    if (!partsList.ContainsKey(name))
                    {
                        partsList.Add(name, new CompoundPart { Name = name });
                    }


                    var compoundPart = (CompoundPart)partsList[name];
                    compoundPart.Parts.Add(new Tuple<BasePart, int>(partsList[simplePartName], count));
                }
            }
        }

    }
}
