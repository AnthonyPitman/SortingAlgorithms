using SortingAlgorithmsCli;

int[] arr = [1, 2, 3, 9, 8, 7, 6, 5, 0, 4];
Console.WriteLine("Before sorting");
Console.WriteLine(string.Join(' ', arr));

BubbleSort.Sort(arr);

Console.WriteLine("After sorting");
Console.WriteLine(string.Join(' ', arr));
