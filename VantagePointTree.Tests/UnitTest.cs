using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using LaXiS.VantagePointTree;

namespace LaXiS.VantagePointTree.Tests
{
    public class UnitTest
    {
        private readonly ITestOutputHelper _output;

        public UnitTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            var items = new List<Point>();

            items.Add(new Point("Point0", 9));
            items.Add(new Point("Point1", 48));
            items.Add(new Point("Point2", 52));
            items.Add(new Point("Point3", 75));
            items.Add(new Point("Point4", 77));
            items.Add(new Point("Point5", 35));
            items.Add(new Point("Point6", 36));
            items.Add(new Point("Point7", 61));
            items.Add(new Point("Point8", 17));
            items.Add(new Point("Point9", 57));
            items.Add(new Point("Point10", 87));
            items.Add(new Point("Point11", 8));
            items.Add(new Point("Point12", 90));
            items.Add(new Point("Point13", 45));
            items.Add(new Point("Point14", 88));
            items.Add(new Point("Point15", 64));
            items.Add(new Point("Point16", 37));
            items.Add(new Point("Point17", 12));
            items.Add(new Point("Point18", 78));
            items.Add(new Point("Point19", 51));

            var vpTree = new VantagePointTree<Point>(items);

            var targetPoint = new Point("PointSearch", 54);
            _output.WriteLine($"Search: {targetPoint}");

            var results = vpTree.Search(targetPoint, 5);
            foreach (var result in results)
                _output.WriteLine($"{result}");

            // TODO must implement IEquatable on Point for this to work as is
            // Assert.Equal(new TreeSearchResult<Point>(new Point("Point2", 52), 2), results[0]);
            // Assert.Equal(new TreeSearchResult<Point>(new Point("Point9", 57), 3), results[1]);
            // Assert.Equal(new TreeSearchResult<Point>(new Point("Point19", 51), 3), results[2]);
            // Assert.Equal(new TreeSearchResult<Point>(new Point("Point1", 48), 6), results[3]);
            // Assert.Equal(new TreeSearchResult<Point>(new Point("Point7", 61), 7), results[4]);
        }
    }

    public class Point : ITreeItem<Point>
    {
        public string Key;
        public int Value;

        public Point(string key, int value)
        {
            Key = key;
            Value = value;
        }

        public double DistanceFrom(Point p)
        {
            return Math.Abs(Value - p.Value);
        }

        public override string ToString()
        {
            return $"Key={Key} Value={Value}";
        }
    }
}
