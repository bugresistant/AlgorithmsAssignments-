```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5335/23H2/2023Update/SunValley3)
12th Gen Intel Core i5-1240P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 8.0.409
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2


```
| Method       | Mean       | Error     | StdDev    | Gen0       | Gen1      | Gen2      | Allocated |
|------------- |-----------:|----------:|----------:|-----------:|----------:|----------:|----------:|
| BuildLinear  |  18.196 ms | 0.5091 ms | 1.5011 ms |  1625.0000 | 1468.7500 |  906.2500 |   9.74 MB |
| BuildBst     |  72.744 ms | 1.4133 ms | 1.4514 ms |  2428.5714 | 1857.1429 | 1000.0000 |  13.92 MB |
| BuildHashSet |   6.082 ms | 0.1170 ms | 0.1095 ms |   992.1875 |  992.1875 |  992.1875 |   8.11 MB |
| BuildTrie    | 120.050 ms | 2.3717 ms | 2.9995 ms | 11000.0000 | 6600.0000 | 2000.0000 |  59.72 MB |
