namespace SortingAlgorithmsCli;

public static class BubbleSort
{
    public static void Sort(int[] arr)
    {
        var upper = arr.GetUpperBound(0);
        for (var outer = upper; outer >= 1; outer--)
        {
            for (var inner = 0; inner <= outer - 1; inner++)
            {
                if (arr[inner] > arr[inner + 1])
                {
                    Utils.Swap(arr, inner, inner + 1);
                }
            }
        }
    }
}

public static class Utils
{
    public static void Swap(int[] arr, int left, int right)
    {
        (arr[left], arr[right]) = (arr[right], arr[left]);
    }
}