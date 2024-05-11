# FizzBuzz

Results benchmarking different implementations:


|                Method | InputValue |        Mean |     Error |    StdDev | Rank |   Gen0 |   Gen1 | Allocated |
|---------------------- |----------- |------------:|----------:|----------:|-----:|-------:|-------:|----------:|
|          FizzBuzzSpan |         10 |    41.66 ns |  0.854 ns |  0.799 ns |    1 | 0.0191 |      - |     240 B |
|     FizzBuzzCharArray |         10 |    54.47 ns |  1.055 ns |  0.935 ns |    2 | 0.0350 |      - |     440 B |
| FizzBuzzStringBuilder |         10 |    67.50 ns |  1.038 ns |  1.154 ns |    3 | 0.0350 |      - |     440 B |
|        FizzBuzzString |         10 |    75.77 ns |  0.314 ns |  0.262 ns |    4 | 0.0554 |      - |     696 B |
|          FizzBuzzEnum |         10 |    95.11 ns |  0.466 ns |  0.364 ns |    5 | 0.0147 |      - |     184 B |
|                       |            |             |           |           |      |        |        |           |
|          FizzBuzzSpan |        100 |   392.66 ns |  7.726 ns | 14.320 ns |    1 | 0.1650 |      - |    2072 B |
| FizzBuzzStringBuilder |        100 |   408.33 ns |  2.384 ns |  2.230 ns |    2 | 0.1836 | 0.0005 |    2304 B |
|     FizzBuzzCharArray |        100 |   502.70 ns |  7.073 ns |  6.270 ns |    3 | 0.3319 | 0.0019 |    4168 B |
|          FizzBuzzEnum |        100 |   854.03 ns |  6.623 ns |  5.531 ns |    4 | 0.0935 |      - |    1176 B |
|        FizzBuzzString |        100 | 2,316.39 ns | 13.616 ns | 12.737 ns |    5 | 3.5286 | 0.0038 |   44304 B |
