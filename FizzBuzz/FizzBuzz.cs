using System.Text;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static string FizzBuzzStringBuilder(int max = 0)
        {
            StringBuilder sb = new();
            for (int n = 0; n <= max; n++)
            {
                if (n % 3 == 0) sb.Append("Fizz");
                if (n % 5 == 0) sb.Append("Buzz");
                if (n % 3 != 0 && n % 5 != 0) sb.Append(n.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
        public static string FizzBuzzString(int max = 0)
        {
            string? result = null;
            if (max % 3 == 0) result += "Fizz ";
            if (max % 5 == 0) result += "Buzz";
            return result ?? max.ToString();
        }
        public static string FizzBuzzSpan(int max)
        {
            int maxDigits = (int)Math.Log10(max) + 1;
            int bufferSize = (max * (maxDigits + 1)) + (max / 3 * 4) + (max / 5 * 4) - (max / 15 * 8) + max;
            char[] resultBuffer = new char[bufferSize];
            Span<char> resultSpan = resultBuffer;

            for (int n = 1; n <= max; n++)
            {
                bool isDivisibleBy3 = n % 3 == 0;
                bool isDivisibleBy5 = n % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    "FizzBuzz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["FizzBuzz".Length..];
                }
                else if (isDivisibleBy3)
                {
                    "Fizz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["Fizz".Length..];
                }
                else if (isDivisibleBy5)
                {
                    "Buzz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["Buzz".Length..];
                }
                else
                {
                    n.TryFormat(resultSpan, out int charsWritten);
                    resultSpan = resultSpan[charsWritten..];
                }

                resultSpan[0] = '\n';
                resultSpan = resultSpan[1..];
            }

            return new string(resultBuffer, 0, resultBuffer.Length - 1);
        }
    }
}
