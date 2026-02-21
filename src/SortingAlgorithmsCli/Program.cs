using System.Diagnostics;

namespace SortingAlgorithmsCli;

public class Program
{
    static void Main()
    {
        const int TimesToRunSorting = 100;
        Stopwatch sw = new();
        long comparisons = 0;
        Console.Write("Enter number of elements to test with (less than 1,000,000,000): ");
        string numberOfElements = Console.ReadLine() ?? "10";
        if (!int.TryParse(numberOfElements, out int value)) return;

        Console.Write("Do you want to accept duplicates (y/N)? ");
        string acceptDuplicates = Console.ReadLine() ?? "N";
        Console.Write("Do you want to have negative numbers (y/N)? ");
        string allowNegatives = Console.ReadLine() ?? "N";
        
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons

        var originalArr = allowNegatives.ToUpperInvariant() == "Y"
            ? Utilities.GenerateArrayWithDuplicates(value, allowNegatives.ToUpperInvariant() == "Y")
            : Utilities.GenerateArray(value, allowNegatives.ToUpperInvariant() == "Y");
        
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
        
        //originalArr.Sort(); // Check for an already sorted array

        List<double> times = []; // TODO: take multiple measurements
        int[] arr = [];

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        for (var i = 0; i <= TimesToRunSorting; i++)
        {
            arr = (int[])originalArr.Clone(); // Copy the original array so we are not sorting an already sorted array
            sw.Restart();

            //BubbleSort.Sort(arr);
            //comparisons = BubbleSort.SortWithComparisons(arr);
            //BubbleSort.SortWithEarlyEnd(arr);
            //comparisons = BubbleSort.SortWithComparisonsWithEarlyEnd(arr);
            
            //SelectionSort.Sort(arr);
            //comparisons = SelectionSort.SortWithComparisons(arr);
            
            //InsertionSort.Sort(arr);
            //comparisons = InsertionSort.SortWithComparisons([1,2,3,4,5,6,7,8,9]);
            
            // QuickSort.Sort(arr);
            //comparisons = QuickSort.SortWithComparisons(arr);
            
            MergeSort.Sort(arr);
            
            sw.Stop();
            times.Add(sw.Elapsed.TotalMicroseconds);
            Console.WriteLine($"({i} of {TimesToRunSorting}) Time to run: {times.Last():N2}us");
        }     

        bool isSorted = Utilities.IsSorted(arr);
        Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Array is sorted: {isSorted}{Environment.NewLine}");
        Console.WriteLine("Skipping 1 outlier.");

        var filtered = times.Skip(1).ToList();
        Console.WriteLine($"Maximum runtime: {filtered.Max():N2}us");
        Console.WriteLine($"Minimum runtime: {filtered.Min():N2}us");
        Console.WriteLine($"Average runtime: {filtered.Average():N2}us");
        Console.WriteLine($"{Environment.NewLine}Number of comparisons: {comparisons}");
        Console.WriteLine($"Ratio = {comparisons / (value * (value - 1) / 2.0)}");
    }
}

