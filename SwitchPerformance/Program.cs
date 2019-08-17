using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Drawing;


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
  
        [Benchmark]
        public Color StandardSwitch()
        {
            switch(_value)
            {
                case Rainbow.Red: return Color.Red;
            }
        }

        private readonly IDictionary<Rainbow,Color> _map = new Dictionary<Rainbow, Color> {
        
            {Rainbow.Red, Color.Red},
             
        };

        [Benchmark]
        public Color If()
        {
            if (Rainbow.Red == _value) return Color.Red;
            throw new Exception("unexpected state");
        }

        [Benchmark]
        public Color DictionarySwitch() => _map[_value];

        [Benchmark]
        public Color SwitchExpression8() => _value switch
        {
            Rainbow.Red => Color.Red
        };
}
