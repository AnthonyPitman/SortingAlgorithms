namespace SortingAlgorithmsCli;

public static class QuickSort
{
    /// <summary>
    /// Time Complexity
    /// Worst case: O(n^2)
    /// Average case: O(n log n)
    /// Best case: O(n log n)
    /// 
    /// Space Complexity average case: O(log n)
    /// Space Complexity worst case: O(n)
    /// 
    /// Not stable by default
    /// Mostly In-place
    /// </summary>
    public static void Sort(int[] numbers)
    {
        QuickSortInternal(numbers, 0, numbers.Length - 1);
    }

    public static long SortWithComparisons(int[] numbers)
    {
        long comparisons = 0;
        QuickSortInternal(numbers, 0, numbers.Length - 1, ref comparisons);
        return comparisons;
    }

    // Add Hoare-partition public APIs
    public static void Sort2(int[] numbers)
    {
        QuickSortInternalHoare(numbers, 0, numbers.Length - 1);
    }

    public static long SortWithComparisons2(int[] numbers)
    {
        long comparisons = 0;
        QuickSortInternalHoare(numbers, 0, numbers.Length - 1, ref comparisons);
        return comparisons;
    }

    // helper: standard Lomuto quicksort
    private static void QuickSortInternal(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(arr, low, high);
            QuickSortInternal(arr, low, pivot - 1);
            QuickSortInternal(arr, pivot + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low;
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                Utilities.Swap(i, j, arr);
                i++;
            }
        }
        Utilities.Swap(i, high, arr);
        return i;
    }

    private static void QuickSortInternal(int[] arr, int low, int high, ref long comparisons)
    {
        if (low < high)
        {
            int p = Partition(arr, low, high, ref comparisons);
            QuickSortInternal(arr, low, p - 1, ref comparisons);
            QuickSortInternal(arr, p + 1, high, ref comparisons);
        }
    }

    private static int Partition(int[] arr, int low, int high, ref long comparisons)
    {
        int pivot = arr[high];
        int i = low;
        for (int j = low; j < high; j++)
        {
            comparisons++; // counting the comparison arr[j] <= pivot
            if (arr[j] <= pivot)
            {
                Utilities.Swap(i, j, arr);
                i++;
            }
        }
        Utilities.Swap(i, high, arr);
        return i;
    }

    private static void QuickSortInternalHoare(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int p = PartitionHoare(arr, low, high);
            QuickSortInternalHoare(arr, low, p);
            QuickSortInternalHoare(arr, p + 1, high);
        }
    }

    private static int PartitionHoare(int[] arr, int low, int high)
    {
        int pivot = arr[(low + high) / 2];
        int i = low - 1;
        int j = high + 1;
        while (true)
        {
            do { i++; } while (arr[i] < pivot);
            do { j--; } while (arr[j] > pivot);
            if (i >= j) return j;
            Utilities.Swap(i, j, arr);
        }
    }

    private static void QuickSortInternalHoare(int[] arr, int low, int high, ref long comparisons)
    {
        if (low < high)
        {
            int p = PartitionHoare(arr, low, high, ref comparisons);
            QuickSortInternalHoare(arr, low, p, ref comparisons);
            QuickSortInternalHoare(arr, p + 1, high, ref comparisons);
        }
    }

    private static int PartitionHoare(int[] arr, int low, int high, ref long comparisons)
    {
        int pivot = arr[(low + high) / 2];
        int i = low - 1;
        int j = high + 1;
        while (true)
        {
            do
            {
                i++;
                comparisons++; // arr[i] < pivot evaluated
            } while (arr[i] < pivot);

            do
            {
                j--;
                comparisons++; // arr[j] > pivot evaluated
            } while (arr[j] > pivot);

            if (i >= j) return j;
            Utilities.Swap(i, j, arr);
        }
    }
}