namespace SortingAlgorithmsCli;

public static class Utilities
{
    public static void Swap(int i, int j, int[] nums)
    {
        (nums[i], nums[j]) = (nums[j], nums[i]);
    }


    public static void Print(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    public static bool IsSorted(int[] arr)
    {
        int previous = arr[0];
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] >= previous)
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public static int[] GenerateArray(int numberOfElements, bool allowDuplicates = false, bool allowNegativeValues = false)
    {
        Random r = new();
        int[] arr = new int[numberOfElements];

        int start = allowNegativeValues ? int.MinValue : 0;
        int end = int.MaxValue;

        if (allowDuplicates)
        {
            for (var i = 0; i < numberOfElements; i++)
            {
                arr[i] = r.Next(start, end);
            }
        }
        else
        {
            int count = 0;
            while (count < numberOfElements)
            {
                var random = r.Next(start, end);
                if (arr.Contains(random)) continue;
                arr[count++] = random;
            }
        }

        return arr;
    }
}