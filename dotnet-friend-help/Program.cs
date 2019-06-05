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

        public List<Tuple<BasePart, int>> SubParts { get; set; } = new List<Tuple<BasePart, int>>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var file = @"./input.txt";
            var parts = ReadFile(file);

            foreach (var part in parts)
            {
                Console.WriteLine($"{part.Value.Name} - {part.Value.IsSimple} - {part.Value.Value}");
            }

        }

        private static Dictionary<string, BasePart> ReadFile(string file)
        {
            var parts = new Dictionary<string, BasePart>();

            using (var fileStream = new StreamReader(file))
            {
                LoadSimpleParts(parts, fileStream);
                LoadCompound(parts, fileStream);
            }
            return parts;
        }

        private static void LoadCompound(Dictionary<string, BasePart> parts, StreamReader fileStream)
        {
            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                var lineInfo = line.Split(" ");
                var name = lineInfo[0];
                var subPartName = lineInfo[1];
                var subPartCount = int.Parse(lineInfo[2]);

                if (!parts.ContainsKey(name))
                {
                    parts.Add(name, new CompoundPart { Name = name });
                }

                var part = (CompoundPart)parts[name];
                var subPart = parts[subPartName];
                part.SubParts.Add(new Tuple<BasePart, int>(subPart, subPartCount));
            }
        }

        private static void LoadSimpleParts(Dictionary<string, BasePart> parts, StreamReader fileStream)
        {
            string line = fileStream.ReadLine();
            var simplePartCount = int.Parse(line);

            for (var i = 0; i < simplePartCount; i++)
            {
                var simplePartInfo = fileStream.ReadLine().Split(" ");
                var simplePart = new SimplePart
                {
                    Name = simplePartInfo[0],
                    Value = int.Parse(simplePartInfo[1])
                };
                parts.Add(simplePart.Name, simplePart);
            }
        }
    }
}
