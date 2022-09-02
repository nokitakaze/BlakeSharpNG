BlakeSharpNG
===========
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

## License
Licensed under the Code Project Open License 1.02.

Author is [Dominik Reichl](http://www.dominik-reichl.de/) <dominik.reichl@t-online.de>, who is also the creator of KeePass.
Source code used with his explicit permission.

Origin source code comes from
- https://www.dominik-reichl.de/projects/blakesharp/
- https://www.codeproject.com/Articles/286937/BlakeSharp-A-Csharp-Implementation-of-the-BLAKE-Ha
