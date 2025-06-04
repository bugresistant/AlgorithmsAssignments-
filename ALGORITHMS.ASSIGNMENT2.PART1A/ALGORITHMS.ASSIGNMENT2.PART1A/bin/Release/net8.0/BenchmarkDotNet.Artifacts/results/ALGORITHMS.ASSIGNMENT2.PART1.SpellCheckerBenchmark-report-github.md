```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5189/23H2/2023Update/SunValley3)
12th Gen Intel Core i5-1240P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 8.0.408
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2


```
| Method       | TextFileName         | Mean            | Error         | StdDev        | Gen0   | Allocated |
|------------- |--------------------- |----------------:|--------------:|--------------:|-------:|----------:|
| **LinearCheck**  | **Alice(...)d.txt [21]** |              **NA** |            **NA** |            **NA** |     **NA** |        **NA** |
| BstCheck     | Alice(...)d.txt [21] |              NA |            NA |            NA |     NA |        NA |
| HashSetCheck | Alice(...)d.txt [21] |              NA |            NA |            NA |     NA |        NA |
| TrieCheck    | Alice(...)d.txt [21] |              NA |            NA |            NA |     NA |        NA |
| **LinearCheck**  | **medium.txt**           | **2,658,309.74 μs** | **52,977.520 μs** | **95,529.404 μs** |      **-** |  **23.65 KB** |
| BstCheck     | medium.txt           |     9,287.61 μs |    173.168 μs |    153.509 μs |      - |  23.26 KB |
| HashSetCheck | medium.txt           |       481.23 μs |      9.454 μs |      8.381 μs | 3.4180 |  23.26 KB |
| TrieCheck    | medium.txt           |       853.99 μs |      4.733 μs |      4.428 μs | 2.9297 |  23.26 KB |
| **LinearCheck**  | **small.txt**            |   **210,148.50 μs** |  **3,139.440 μs** |  **2,936.634 μs** |      **-** |   **2.91 KB** |
| BstCheck     | small.txt            |       729.16 μs |      9.124 μs |      8.534 μs |      - |   2.78 KB |
| HashSetCheck | small.txt            |        19.09 μs |      0.213 μs |      0.189 μs | 0.4272 |   2.78 KB |
| TrieCheck    | small.txt            |        51.61 μs |      0.296 μs |      0.277 μs | 0.4272 |   2.78 KB |

Benchmarks with issues:
  SpellCheckerBenchmark.LinearCheck: DefaultJob [TextFileName=Alice(...)d.txt [21]]
  SpellCheckerBenchmark.BstCheck: DefaultJob [TextFileName=Alice(...)d.txt [21]]
  SpellCheckerBenchmark.HashSetCheck: DefaultJob [TextFileName=Alice(...)d.txt [21]]
  SpellCheckerBenchmark.TrieCheck: DefaultJob [TextFileName=Alice(...)d.txt [21]]
