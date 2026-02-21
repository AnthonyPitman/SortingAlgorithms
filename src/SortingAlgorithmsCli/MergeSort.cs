namespace SortingAlgorithmsCli;

public class MergeSort
{
    public static void Sort(int[] arr)
    {
        SortInternal(arr, 0, arr.Length - 1);
    }

    private static void SortInternal(int[] arr, int left, int right)
    {
        if (left >= right)
            return;

        int mid = left + (right - left) / 2;

        SortInternal(arr, left, mid);
        SortInternal(arr, mid + 1, right);
        
        Merge(arr, left, mid, right);
    }

    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int leftSize = mid - left + 1;
        int rightSize = right - mid;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        for (int i = 0; i < leftSize; i++)
            leftArray[i] = arr[left + i];

        for (int i = 0; i < rightSize; i++)
            rightArray[i] = arr[mid + 1 + i];

        int l = 0, r = 0;
        int k = left;

        while (l < leftSize && r < rightSize)
        {
            if (leftArray[l] <= rightArray[r])
                arr[k++] = leftArray[l++];
            else
                arr[k++] = rightArray[r++];
        }

        while (l < leftSize)
            arr[k++] = leftArray[l++];

        while (r < rightSize)
            arr[k++] = rightArray[r++];
    }
}