using System;
using System.Linq;
using BenchmarkDotNet.Running;
using BlakeSharpNG.Benchmark.Main;

namespace BlakeSharpNG.Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            var summaryMain = BenchmarkRunner.Run<Generator>();

            Console.WriteLine("==================================");
            Console.WriteLine("==================================");
            Console.WriteLine("==================================");

            var items = summaryMain
                .Reports
                .Select(report =>
                {
                    var caseItem = report.BenchmarkCase;
                    var paramDictionary = caseItem
                        .Parameters
                        .Items
                        .Where(x => x.Value is int)
                        .ToDictionary(t => t.Name, t => (int)t.Value);

                    var displayInfo = caseItem.Descriptor.DisplayInfo;
                    var byteCount = paramDictionary["RepeatCount"] * paramDictionary["BlockSize"];
                    var countPerSec = 1_000_000_000d / report.ResultStatistics!.Mean;
                    var bytePerSec = byteCount * countPerSec;

                    return (displayInfo, mbPerSec: bytePerSec * (1d / 1024 / 1024));
                })
                .ToArray();
            items
                .GroupBy(t => t.displayInfo)
                .ToList()
                .ForEach(t =>
                {
                    var values = t
                        .Select(t1 => t1.mbPerSec)
                        .OrderByDescending(t1 => t1)
                        .ToArray();
                    var value = (values.Length > 1) ? values[1] : values[0];

                    Console.WriteLine("{0}\t{1:F2} MB/sec", t.Key, value);
                });
        }
    }
}