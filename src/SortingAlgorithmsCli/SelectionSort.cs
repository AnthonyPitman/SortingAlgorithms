namespace SortingAlgorithmsCli;

public static class SelectionSort
{
    /// <summary>
    /// Time Complexity
    /// Worst case: O(n^2)
    /// Average case: O(n^2)
    /// Best case: O(n^2)
    /// 
    /// Space Complexity: O(1)
    /// 
    /// Not stable by default
    /// In-place
    /// </summary>
    public static void Sort(int[] numbers)
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            
            Utilities.Swap(i, minIndex, numbers);
        }
    }

    // Series (n - 1) + (n - 2) + (n - 3) + ... + 1
    // Note that the count is expressed with this formula `(n(n-1)) / 2` which simplifies of `(n^2 - n) / 2`
    public static long SortWithComparisons(int[] numbers)
    {
        long comparisons = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < numbers.Length; j++)
            {
                comparisons++;
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            
            Utilities.Swap(i, minIndex, numbers);
        }

        return comparisons;
    }
}