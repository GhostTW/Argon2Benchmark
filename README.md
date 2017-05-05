# Argon2Benchmark

A Benchmark application to know the result that run Argon2 algorithm on your target machine.

using [Konscious.Security.Cryptography package](https://github.com/kmaragon/Konscious.Security.Cryptography).

## How to use

1. `dotnet restore`
1. `dotnet run password salt uuid secret 0 2 5120 10 256`

## Arguments

1. password
1. salt
1. associatedData
1. knownSecret
1. 0:i , 1:d , 2:id
1. degreeOfParallelism
1. memorySize
1. iterations
1. resultLength

## build exe

`dotnet publish -c Release -r win10-x64`

### Sample
```cmd
>Argon2Benchmark.exe password salt uuid secret 0 2 5120 10 256
args: password salt uuid secret 0 2 5120 10 256
Elapsed: 00:00:00.1801720
result: System.Byte[]
result length: 256
result base64: NaMbqbULIVk0l7Fxu09BNHu21/yCiwD94ZcB9KshPRpXJQxNY0Xuw3SL6qT/cGZJA2xTsz9XtdiraxcuVcP+DV8nzuCwpvtGcjykt+PXh7ZJqfoxwR+wlR0SBsXAiPqa8HRwza30TduMha9Y8qGF1X6TrxC3aHJIPcMn8AM14GLBUxG7nm+tYq03dTIScnbI3+cc3ihwdJxoeWpTKMQTfygyrLo07RioDDub/2o6smr7aQT0Q5zJILhRJErPRsLxN6YzGbk9l15AnAhsYIWq1AT1EewB23iR+eZMtVSraijpuG6QvKmTLHhWABxK5QY6TyAEF7Xr8k1egyJJ8R14jw==
result base64 length: 344
```
