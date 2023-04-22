using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FizzBuzz
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Default)]
    [RankColumn]
    public class FizzBuzzBenchmarks
    {
        [Params(10, 100, 1_000)]
        public int InputValue { get; set; }
        //private static readonly FizzBuzz Fb = new();

        [Benchmark]
        public void FbStringBuilder()
        {
            FizzBuzz.FizzBuzzStringBuilder(InputValue);
        }

        [Benchmark]
        public void FbString()
        {
            FizzBuzz.FizzBuzzString(InputValue);
        }
        [Benchmark]
        public void FbSpan()
        {
            FizzBuzz.FizzBuzzSpan(InputValue);
        }
    }
}
