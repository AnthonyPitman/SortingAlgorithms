using System.Diagnostics;

namespace SortingAlgorithmsCli;

internal static class Program
{
    const int MaxSize = 10_000;

    static void Main()
    {
        Console.Write("How many runs? ");
        if (!int.TryParse(Console.ReadLine(), out int runs) || runs <= 0)
        {
            Console.WriteLine("Invalid number of runs.");
            return;
        }

        Console.Write("Array size? ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Invalid array size.");
            return;
        }

        double totalMilliseconds = 0;
        double totalMicroseconds = 0;
        double totalNanoseconds = 0;
        double totalSeconds = 0;

        int[] original = GenerateRandomArray(size);

        for (int i = 0; i < runs; i++)
        {
            int[] arr = (int[])original.Clone(); // clone to avoid modifying original

            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSort.Sort(arr);
            stopwatch.Stop();

            totalSeconds += stopwatch.Elapsed.TotalSeconds;
            totalMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
            totalMicroseconds += stopwatch.Elapsed.TotalMicroseconds;
            totalNanoseconds += stopwatch.Elapsed.TotalNanoseconds;
        }

        Console.WriteLine($"\nAverage time over {runs} runs:");
        double averageSeconds = totalSeconds / runs;
        double averageMilliseconds = totalMilliseconds / runs;
        double averageMicroseconds = totalMicroseconds / runs;
        double averageNanoseconds = totalNanoseconds / runs;

        Console.WriteLine($"Seconds     : {averageSeconds} s");
        Console.WriteLine($"Milliseconds: {averageMilliseconds} ms");
        Console.WriteLine($"Microseconds: {averageMicroseconds} us");
        Console.WriteLine($"Nanoseconds : {averageNanoseconds} ns");

        var operationCount = BubbleSort.SortWithOperationCount((int[])original.Clone());
        Console.WriteLine($"Operation count: {operationCount}");
    }

    static int[] GenerateRandomArray(int size)
    {
        Random rand = new();
        int[] arr = new int[size];
        for (var i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, MaxSize);
        }

        return arr;
    }
}