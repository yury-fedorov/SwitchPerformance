# StringInterpolationPerformance

String Interpolation vs String Format, String Concat and String Builder performance benchmarks

## How to run the test
```
dotnet run -c Release
```

## Summary
```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.885 (1803/April2018Update/Redstone4)
Intel Core i7-2670QM CPU 2.20GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
Frequency=2143566 Hz, Resolution=466.5123 ns, Timer=TSC
.NET Core SDK=2.2.301
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
```

```
|              Method |     Mean |     Error |   StdDev |
|-------------------- |---------:|----------:|---------:|
|        StringFormat | 474.6 ns | 21.135 ns | 61.65 ns |
| StringInterpolation | 182.8 ns |  5.666 ns | 16.35 ns |
|        StringConcat | 173.9 ns |  6.745 ns | 19.46 ns |
|       StringBuilder | 505.1 ns | 25.581 ns | 74.62 ns |
```