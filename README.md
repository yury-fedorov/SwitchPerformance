# SwitchPerformance

Switch performance alternatives in C# 8 benchmarks

## How to run the test
```
dotnet run -c Release
```

## Summary
```
BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.6 (18G87) [Darwin 18.7.0]
Intel Core i7-6567U CPU 3.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100-preview8-013656
  [Host]     : .NET Core 3.0.0-preview8-28405-07 (CoreCLR 4.700.19.37902, CoreFX 4.700.19.40503), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview8-28405-07 (CoreCLR 4.700.19.37902, CoreFX 4.700.19.40503), 64bit RyuJIT
```

|            Method |       Mean |     Error |    StdDev |
|------------------ |-----------:|----------:|----------:|
|    StandardSwitch |  1.2653 ns | 0.0105 ns | 0.0088 ns |
|                If |  0.8167 ns | 0.0159 ns | 0.0141 ns |
|  DictionarySwitch | 10.6743 ns | 0.2446 ns | 0.3004 ns |
| SwitchExpression8 |  6.4470 ns | 0.0289 ns | 0.0271 ns |
