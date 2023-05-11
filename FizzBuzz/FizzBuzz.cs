using System.Text;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static string FizzBuzzStringBuilder(int max = 0)
        {
            StringBuilder sb = new();

            for (int n = 1; n <= max; n++)
            {
                bool isDivisibleBy3 = n % 3 == 0;
                bool isDivisibleBy5 = n % 5 == 0;
                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    sb.Append("FizzBuzz");
                }
                else if (isDivisibleBy3)
                {
                    sb.Append("Fizz");
                }
                else if (isDivisibleBy5)
                {
                    sb.Append("Buzz");
                }
                else
                {
                    sb.Append(n);
                }
                sb.Append(',');
            }
            return sb.ToString(0, sb.Length - 1);
        }
        public static string FizzBuzzString(int max = 1)
        {
            string s = string.Empty;
            for (int n = 1; n <= max; n++)
            {
                bool isDivisibleBy3 = n % 3 == 0;
                bool isDivisibleBy5 = n % 5 == 0;
                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    s += "FizzBuzz,";
                }
                else if (isDivisibleBy3)
                {
                    s += "Fizz,";

                }
                else if (isDivisibleBy5)
                {
                    s += "Buzz,";
                }
                else
                {
                    s += n.ToString() + ",";
                }
            }
            return s[..^1];
        }
        public static string FizzBuzzSpan(int max)
        {
            if (max > 150_000) throw new Exception("Too high numer.  Adjust resultbuffer size");
            char[] resultBuffer = new char[6 * max];
            Span<char> resultSpan = resultBuffer;
            int totalLength = 0;

            for (int n = 1; n <= max; n++)
            {
                bool isDivisibleBy3 = n % 3 == 0;
                bool isDivisibleBy5 = n % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    "FizzBuzz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["FizzBuzz".Length..];
                    totalLength += 8;
                }
                else if (isDivisibleBy3)
                {
                    "Fizz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["Fizz".Length..];
                    totalLength += 4;
                }
                else if (isDivisibleBy5)
                {
                    "Buzz".AsSpan().CopyTo(resultSpan);
                    resultSpan = resultSpan["Buzz".Length..];
                    totalLength += 4;
                }
                else
                {
                    n.TryFormat(resultSpan, out int charsWritten);
                    resultSpan = resultSpan[charsWritten..];
                    totalLength += charsWritten;
                }
                if (n != max)
                {
                    resultSpan[0] = ',';
                    resultSpan = resultSpan[1..];
                    totalLength += 1;
                }
            }
            return new string(resultBuffer, 0, totalLength);
        }
        public static string FizzBuzzCharArray(int n)
        {
            char[] output = new char[n * 8]; // allocate enough space for the maximum possible output (8 characters per value)

            int index = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                {
                    output[index++] = 'F';
                    output[index++] = 'i';
                    output[index++] = 'z';
                    output[index++] = 'z';
                    output[index++] = 'B';
                    output[index++] = 'u';
                    output[index++] = 'z';
                    output[index++] = 'z';
                }
                else if (i % 3 == 0)
                {
                    output[index++] = 'F';
                    output[index++] = 'i';
                    output[index++] = 'z';
                    output[index++] = 'z';
                }
                else if (i % 5 == 0)
                {
                    output[index++] = 'B';
                    output[index++] = 'u';
                    output[index++] = 'z';
                    output[index++] = 'z';
                }
                else
                {
                    char[] num = i.ToString().ToCharArray();
                    for (int j = 0; j < num.Length; j++)
                    {
                        output[index++] = num[j];
                    }
                }

                if (i < n)
                {
                    output[index++] = ',';
                }
            }

            return new string(output, 0, index);
        }

        public static string FizzBuzzEnum(int n)
        {
            IEnumerable<string> fizzBuzz = Enumerable.Range(1, n)
                .Select(i => (i % 3 == 0 ? "Fizz" : "") + (i % 5 == 0 ? "Buzz" : "") + (i % 3 != 0 && i % 5 != 0 ? i.ToString() : ""));

            return string.Join(",", fizzBuzz);
        }

    }
}
