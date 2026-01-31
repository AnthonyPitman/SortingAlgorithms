namespace SortingAlgorithmsCli;

public static class BubbleSort
{
    /// <summary>
    /// Time Complexity
    /// Worst case: O(n^2)
    /// Average case: O(n^2)
    /// Best case without early ending: O(n^2)
    /// Best case with early ending: O(n)
    /// 
    /// Space Complexity: O(1)
    /// 
    /// Stable
    /// </summary>
    public static void Sort(int[] numbers)
    {
        for (int end = numbers.Length - 1; end > 0; end--)
        {
            for (int i = 0; i < end; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Utilities.Swap(i, i + 1, numbers);
                }
            }
        }
    }

    public static void SortWithEarlyEnd(int[] numbers)
    {
        for (int end = numbers.Length - 1; end > 0; end--)
        {
            bool isSwapped = false;
            for (int i = 0; i < end; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Utilities.Swap(i, i + 1, numbers);
                    isSwapped = true;
                }
            }

            if (!isSwapped) break;
        }
    }

    public static long SortWithComparisons(int[] numbers)
    {
        int countOfComparisons = 0;

        for (int end = numbers.Length - 1; end > 0; end--)
        {
            for (int i = 0; i < end; i++)
            {
                countOfComparisons++;
                if (numbers[i] > numbers[i + 1])
                {
                    Utilities.Swap(i, i + 1, numbers);
                }
            }
        }

        return countOfComparisons;
    }

    public static long SortWithComparisonsWithEarlyEnd(int[] numbers)
    {
        int countOfComparisons = 0;

        for (int end = numbers.Length - 1; end > 0; end--) 
        {
            bool isSwapped = false;

            for (int i = 0; i < end; i++)
            { 
                countOfComparisons++;
                if (numbers[i] > numbers[i + 1])
                {
                    Utilities.Swap(i, i + 1, numbers);
                    isSwapped = true;
                }
            }

            if (!isSwapped) break;
        }

        return countOfComparisons;
    }
}
