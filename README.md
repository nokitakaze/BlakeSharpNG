BlakeSharpNG
===========
[![Build status](https://ci.appveyor.com/api/projects/status/r5qb64o5u2pjqkyf/branch/master?svg=true)](https://ci.appveyor.com/project/nokitakaze/BlakeSharpNG/branch/master)
[![Test status](https://img.shields.io/appveyor/tests/nokitakaze/BlakeSharpNG/master)](https://ci.appveyor.com/project/nokitakaze/BlakeSharpNG/branch/master)
[![codecov](https://codecov.io/gh/nokitakaze/BlakeSharpNG/branch/master/graph/badge.svg)](https://codecov.io/gh/nokitakaze/BlakeSharpNG)
[![Nuget version](https://badgen.net/nuget/v/BlakeSharpNG)](https://www.nuget.org/packages/BlakeSharpNG)
[![Total nuget downloads](https://badgen.net/nuget/dt/BlakeSharpNG)](https://www.nuget.org/packages/BlakeSharpNG)

This project is a C# implementation of original [Blake](https://en.wikipedia.org/wiki/BLAKE_(hash_function)). BLAKE is a cryptographic hash function based on Daniel J. Bernstein's ChaCha stream cipher, but a permuted copy of the input block. BLAKE was submitted to the NIST hash function competition as a proposal for next SHA-3 algorithm.

## Public Classes
Classes `Blake256` & `Blake512` implement standard `System.Security.Cryptography.HashAlgorithm`.

### Example
```C#
using var algo = new Blake256();
var hash = algo.ComputeHash("Hello, world");
var hashString = string.Concat(hash.Select(t => t.ToString("x2")));
Console.WriteLine(hashString);
```

## Benchmark
[Main benchmark](docs/main-benchmark.md)

On AMD Ryzen 9 3900X BOX 3.8 GHz:
- `Blake256` — 38.72 MB/sec
- `Blake512` — 65.82 MB/sec

## License
Licensed under the Code Project Open License 1.02.

Author is [Dominik Reichl](http://www.dominik-reichl.de/) <dominik.reichl@t-online.de>, who is also the creator of KeePass.
Source code used with his explicit permission.

Origin source code comes from
- https://www.dominik-reichl.de/projects/blakesharp/
- https://www.codeproject.com/Articles/286937/BlakeSharp-A-Csharp-Implementation-of-the-BLAKE-Ha
