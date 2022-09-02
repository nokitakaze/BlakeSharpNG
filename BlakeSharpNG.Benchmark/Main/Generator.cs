using BenchmarkDotNet.Attributes;

namespace BlakeSharpNG.Benchmark.Main
{
    public class Generator
    {
        // ReSharper disable once ConvertToConstant.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        [Params(100, 1000)]
        public int RepeatCount = 0;

        // ReSharper disable once ConvertToConstant.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        [Params(1024, 10 * 1024, 1024 * 1024)]
        public int BlockSize = 0;

        private byte[] _input;

        [GlobalSetup]
        public void Setup()
        {
            _input = new byte[BlockSize];
        }

        [Benchmark]
        public void Blake256()
        {
            var input = _input;

            for (var i = 0; i < RepeatCount; i++)
            {
                using var algo = new Blake256();
                algo.ComputeHash(input);

                //*
                var x = (byte)(i % 0x100);
                for (var j = 0; j < input.Length; j++)
                {
                    input[j] = (byte)(input[j] ^ x);
                }
                // */
            }
        }

        [Benchmark]
        public void Blake512()
        {
            var input = _input;

            for (var i = 0; i < RepeatCount; i++)
            {
                using var algo = new Blake512();
                algo.ComputeHash(input);

                //*
                var x = (byte)(i % 0x100);
                for (var j = 0; j < input.Length; j++)
                {
                    input[j] = (byte)(input[j] ^ x);
                }
                // */
            }
        }
    }
}