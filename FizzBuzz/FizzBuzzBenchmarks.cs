using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FizzBuzz
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
    [RankColumn]
    public class FizzBuzzBenchmarks
    {
        [Params(10, 100)]
        public int InputValue { get; set; }

        [Benchmark]
        public void FizzBuzzStringBuilder()
        {
            FizzBuzz.FizzBuzzStringBuilder(InputValue);
        }
        [Benchmark]
        public void FizzBuzzString()
        {
            FizzBuzz.FizzBuzzString(InputValue);
        }
        [Benchmark]
        public void FizzBuzzSpan()
        {
            FizzBuzz.FizzBuzzSpan(InputValue);
        }
        [Benchmark]
        public void FizzBuzzCharArray()
        {
            FizzBuzz.FizzBuzzCharArray(InputValue);
        }
        [Benchmark]
        public void FizzBuzzEnum()
        {
            FizzBuzz.FizzBuzzEnum(InputValue);
        }
    }
}
