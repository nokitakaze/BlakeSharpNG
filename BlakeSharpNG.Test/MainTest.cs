using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace BlakeSharpNG.Test
{
    public class MainTest
    {
        private static readonly IList<byte[]> InputDatum = new List<byte[]>();
        private static readonly object[][] InputProcessed;

        static MainTest()
        {
            var lines = File.ReadAllLines("data/test-blake.tsv");
            var inputRaw = lines
                .Select(line =>
                {
                    var a = line.Split("\t").ToArray();

                    return (input: a, blake256: a[1], blake512: a[2]);
                })
                .ToArray();
            InputProcessed = inputRaw
                .Select(t =>
                {
                    byte[] input;
                    switch (t.input[0])
                    {
                        case "hafa":
                        {
                            var i = int.Parse(t.input[3]);
                            var j = byte.Parse(t.input[4]);

                            input = new byte[i + 1];
                            input[i] = j;

                            /* input = Enumerable
                                .Repeat(0, i)
                                .Select(t1 => (byte)t1)
                                .Concat(new[] { j })
                                .ToArray(); */
                            break;
                        }
                        case "stairs":
                        {
                            var i = int.Parse(t.input[3]);
                            var j = int.Parse(t.input[4]);

                            input = Enumerable
                                .Range(i, j - i + 1)
                                .Select(t1 => (byte)t1)
                                .ToArray();
                            break;
                        }
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return new object[] { input, t.blake256, t.blake512 };
                })
                .Concat(new[]
                {
                    new object[]
                    {
                        Array.Empty<byte>(),
                        "716f6e863f744b9ac22c97ec7b76ea5f5908bc5b2f67c61510bfc4751384ea7a",
                        "a8cfbbd73726062df0c6864dda65defe58ef0cc52a5625090fa17601e1eecd1b628e94f396ae402a00acc9eab77b4d4c2e852aaaa25a636d80af3fc7913ef5b8"
                    },
                })
                .Select((datum, index) =>
                {
                    if (InputDatum.Count != index)
                    {
                        throw new Exception();
                    }

                    InputDatum.Add((byte[])datum[0]);

                    return new object[] { index, datum[1], datum[2] };
                })
                .ToArray();
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            return InputProcessed;
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void MainTestCase(int inputId, string expectedBlake256, string expectedBlake512)
        {
            byte[] input = InputDatum[inputId];

            {
                using var algo = new Blake256();
                var hash = algo.ComputeHash(input);
                Assert.Equal(32, hash.Length);
                var hashString = string.Concat(hash.Select(t => t.ToString("x2")));
                Assert.Equal(expectedBlake256, hashString);
            }
            {
                using var algo = new Blake512();
                var hash = algo.ComputeHash(input);
                Assert.Equal(64, hash.Length);
                var hashString = string.Concat(hash.Select(t => t.ToString("x2")));
                Assert.Equal(expectedBlake512, hashString);
            }
        }
    }
}