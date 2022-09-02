# Main benchmark
## AMD Ryzen 9 3900X BOX 3.8 GHz (Matisse) & Windows 10 
```ini
BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1826/21H2/November2021Update)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.203
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT AVX2
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT AVX2
```

- `Blake256` — 38.72 MB/sec
- `Blake512` — 65.82 MB/sec

|   Method | RepeatCount | BlockSize |          Mean |       Error |      StdDev |
|--------- |------------ |---------- |--------------:|------------:|------------:|
| Blake256 |         100 |      1024 |      2.654 ms |   0.0297 ms |   0.0278 ms |
| Blake512 |         100 |      1024 |      1.606 ms |   0.0100 ms |   0.0094 ms |
| Blake256 |         100 |     10240 |     24.871 ms |   0.2811 ms |   0.2492 ms |
| Blake512 |         100 |     10240 |     14.139 ms |   0.0614 ms |   0.0545 ms |
| Blake256 |         100 |   1048576 |  2,510.745 ms |  10.3745 ms |   8.6632 ms |
| Blake512 |         100 |   1048576 |  1,459.505 ms |   9.0668 ms |   8.0375 ms |
| Blake256 |        1000 |      1024 |     26.273 ms |   0.2124 ms |   0.1987 ms |
| Blake512 |        1000 |      1024 |     16.009 ms |   0.0587 ms |   0.0458 ms |
| Blake256 |        1000 |     10240 |    248.366 ms |   1.8832 ms |   1.7616 ms |
| Blake512 |        1000 |     10240 |    145.073 ms |   1.5641 ms |   1.3865 ms |
| Blake256 |        1000 |   1048576 | 25,441.610 ms | 107.8541 ms | 100.8868 ms |
| Blake512 |        1000 |   1048576 | 14,592.527 ms |  84.3568 ms |  74.7801 ms |

## Intel Core i7-10875H CPU 2.30GHz & Windows 10
```ini
BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19043.1826/21H1/May2021Update)
Intel Core i7-10875H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=5.0.408
  [Host]     : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  DefaultJob : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
```

- `Blake256` — 35.05 MB/sec
- `Blake512` — 59.55 MB/sec

|   Method | RepeatCount | BlockSize |          Mean |       Error |      StdDev |
|--------- |------------ |---------- |--------------:|------------:|------------:|
| Blake256 |         100 |      1024 |      2.964 ms |   0.0193 ms |   0.0151 ms |
| Blake512 |         100 |      1024 |      1.867 ms |   0.0347 ms |   0.0509 ms |
| Blake256 |         100 |     10240 |     27.673 ms |   0.0991 ms |   0.0927 ms |
| Blake512 |         100 |     10240 |     16.570 ms |   0.2249 ms |   0.1994 ms |
| Blake256 |         100 |   1048576 |  2,889.817 ms |  26.0564 ms |  24.3732 ms |
| Blake512 |         100 |   1048576 |  1,679.205 ms |   8.4893 ms |   7.5255 ms |
| Blake256 |        1000 |      1024 |     30.640 ms |   0.1437 ms |   0.1345 ms |
| Blake512 |        1000 |      1024 |     19.028 ms |   0.1935 ms |   0.1511 ms |
| Blake256 |        1000 |     10240 |    282.755 ms |   2.1250 ms |   1.7745 ms |
| Blake512 |        1000 |     10240 |    166.504 ms |   1.7997 ms |   1.5029 ms |
| Blake256 |        1000 |   1048576 | 28,530.003 ms | 122.5037 ms | 108.5963 ms |
| Blake512 |        1000 |   1048576 | 16,689.179 ms |  51.0060 ms |  42.5923 ms |
