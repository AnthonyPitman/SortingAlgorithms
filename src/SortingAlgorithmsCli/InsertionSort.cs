namespace SortingAlgorithmsCli;

public static class InsertionSort
{
    /// <summary>
    /// Time Complexity
    /// Worst case: O(n^2)
    /// Average case: O(n^2)
    /// Best case: O(n)
    /// 
    /// Space Complexity: O(1)
    /// 
    /// Not stable by default
    /// In-place
    /// </summary>
    public static void Sort(int[] numbers)
    {
        for (var i = 1; i < numbers.Length; i++)
        {
            var key = numbers[i];
            var j = i - 1;

            while (j >= 0)
            {
                if (numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                else
                {
                    break;
                }
            }

            numbers[j + 1] = key;
        }
    }

    public static long SortWithComparisons(int[] numbers)
    {
        long comparisons = 0;
        
        for (var i = 1; i < numbers.Length - 1; i++)
        {
            var key = numbers[i];
            var j = i - 1;

            while (j >= 0)
            {
                comparisons++;
                if (numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                else
                {
                    break;
                }
            }

            numbers[j + 1] = key;
        }

        return comparisons;
    }
}