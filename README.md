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

|            Method |      Mean |     Error |    StdDev |
|------------------ |----------:|----------:|----------:|
|        ArrayAsMap |  3.326 ns | 0.0345 ns | 0.0322 ns |
|    StandardSwitch |  1.177 ns | 0.0188 ns | 0.0176 ns |
|                If |  1.460 ns | 0.0190 ns | 0.0169 ns |
|  DictionarySwitch | 10.297 ns | 0.0832 ns | 0.0778 ns |
| SwitchExpression8 |  6.100 ns | 0.0430 ns | 0.0381 ns |
