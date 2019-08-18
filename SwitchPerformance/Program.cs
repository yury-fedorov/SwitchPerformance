using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace SwitchPerformance
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<SwitchPerformanceTest>();
    }

    // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public class SwitchPerformanceTest
    {
        private readonly Rainbow _value = (Rainbow)(int)Math.Round(new Random().NextDouble() * (int)Rainbow.Violet);

        private readonly IDictionary<Rainbow, Color> _map = new Dictionary<Rainbow, Color> {

            {Rainbow.Red, Color.Red},
            {Rainbow.Orange, Color.Orange},
            {Rainbow.Yellow, Color.Yellow},
            {Rainbow.Green, Color.Green},
            {Rainbow.Blue, Color.Blue},
            {Rainbow.Indigo, Color.Indigo},
            {Rainbow.Violet, Color.Violet}
        };

        private readonly Color[] _arrayMap;

        public SwitchPerformanceTest() 
        {
            var max = _map.Keys.Max(k => (int)k); 
            _arrayMap = new Color[max +1];
            foreach( var p in _map)
            {
                _arrayMap[(int)p.Key] = p.Value;
            }
        }

        [Benchmark]
        public Color ArrayAsMap() => _arrayMap[(int)_value];

        [Benchmark]
        public Color StandardSwitch()
        {
            switch(_value)
            {
                case Rainbow.Red:    return Color.Red;
                case Rainbow.Orange: return Color.Orange;
                case Rainbow.Yellow: return Color.Yellow;
                case Rainbow.Green:  return Color.Green;
                case Rainbow.Blue:   return Color.Blue;
                case Rainbow.Indigo: return Color.Indigo;
                case Rainbow.Violet: return Color.Violet;
            }
            throw new Exception("unexpected state");
        }

        [Benchmark]
        public Color If()
        {
            if (Rainbow.Red == _value) return Color.Red;
            if (Rainbow.Orange == _value) return Color.Orange;
            if (Rainbow.Yellow == _value) return Color.Yellow;
            if (Rainbow.Green == _value) return Color.Green;
            if (Rainbow.Blue == _value) return Color.Blue;
            if (Rainbow.Indigo == _value) return Color.Indigo;
            if (Rainbow.Violet == _value) return Color.Violet;
            throw new Exception("unexpected state");
        }

        [Benchmark]
        public Color DictionarySwitch() => _map[_value];

        [Benchmark]
        public Color SwitchExpression8() => _value switch
        {
            Rainbow.Red => Color.Red,
            Rainbow.Orange => Color.Orange,
            Rainbow.Yellow => Color.Yellow,
            Rainbow.Green => Color.Green,
            Rainbow.Blue => Color.Blue,
            Rainbow.Indigo => Color.Indigo,
            Rainbow.Violet => Color.Violet,
            _ => throw new Exception("unexpected state")
        };
    }
}
