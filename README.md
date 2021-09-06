# Challenge - String Code Generator

This program generate string codes with rules below:
  - Each line has 7 chars.
  - Each char is a letter (numbers and special chars are not generated).
  - Each code is unique (don't repeat codes).

Some used principles:
  - Design patters: Facade and SOLID (Single Responsibility), OO Stands (each class do only little function).
  - Resources: Thread-Safe, parallel programming, permutation principle (combinatorial analysis), Concurrent .NET namespace.

### Benchmark
| Linhas | Tempo   |
|  ----  | -----   |
|10      |14ms     |
|100     |19ms     |
|1000    |21ms     |
|10000   |30ms     |
|100000  |190ms    |
|1000000 |2810ms   |
|10000000|98721ms  |

## How to run

Write `dotnet run` command inside current directory.
