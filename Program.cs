using System.Diagnostics;

int arrLength = 100000;
// BUBBLE SORT
TestAlgorithmOnArray(GenerateRandomArray(arrLength, 1, 1000), "Random", "Bubble Sort", 1);
TestAlgorithmOnArray(GenerateSortedArray(arrLength), "Sorted", "Bubble Sort", 1);
TestAlgorithmOnArray(GenerateReverseSortedArray(arrLength), "Reverse Sorted", "Bubble Sort", 1);
TestAlgorithmOnArray(GeneratePartiallySortedArray(arrLength), "Partial", "Bubble Sort", 1);

// INSERTION SORT
TestAlgorithmOnArray(GenerateRandomArray(arrLength, 1, 1000), "Random", "Insertion Sort", 2);
TestAlgorithmOnArray(GenerateSortedArray(arrLength), "Sorted", "Insertion Sort", 2);
TestAlgorithmOnArray(GenerateReverseSortedArray(arrLength), "Reverse Sorted", "Insertion Sort", 2);
TestAlgorithmOnArray(GeneratePartiallySortedArray(arrLength), "Partial", "Insertion Sort", 2);

// MERGE SORT
TestAlgorithmOnArray(GenerateRandomArray(arrLength, 1, 1000), "Random", "Merge Sort", 3);
TestAlgorithmOnArray(GenerateSortedArray(arrLength), "Sorted", "Merge Sort", 3);
TestAlgorithmOnArray(GenerateReverseSortedArray(arrLength), "Reverse Sorted", "Merge Sort", 3);
TestAlgorithmOnArray(GeneratePartiallySortedArray(arrLength), "Partial", "Merge Sort", 3);

// QUICK SORT
TestAlgorithmOnArray(GenerateRandomArray(arrLength, 1, 1000), "Random", "Quick Sort", 4);
TestAlgorithmOnArray(GenerateSortedArray(arrLength), "Sorted", "Quick Sort", 4);
TestAlgorithmOnArray(GenerateReverseSortedArray(arrLength), "Reverse Sorted", "Quick Sort", 4);
TestAlgorithmOnArray(GeneratePartiallySortedArray(arrLength), "Partial", "Quick Sort", 4);


// Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)


static void TestAlgorithmOnArray(int[] arr, string arrayType, string algorithmName, int algorithmNumber)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    if (algorithmNumber == 1)
    {
        bubbleSort(arr, arr.Length);
    }
    else if (algorithmNumber == 2)
    {
        insertionSort(arr);
    }
    else if (algorithmNumber == 3)
    {
        mergeSort(arr, 0, arr.Length - 1);
    }
    else if (algorithmNumber == 4)
    {
        quickSort(arr, 0, arr.Length - 1);
    }

    stopwatch.Stop();

    Console.WriteLine($"{algorithmName} on {arrayType} Array:");
    DisplayRuntime(stopwatch);
    Console.WriteLine();
}

static void insertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            /* Move elements of arr[0..i-1], that are
               greater than key, to one position ahead
               of their current position */
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    static void bubbleSort(int[] arr, int n)
{
    int i, j, temp;
    bool swapped;
    for (i = 0; i < n - 1; i++)
    {
        swapped = false;
        for (j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {

                // Swap arr[j] and arr[j+1]
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
                swapped = true;
            }
        }

        if (swapped == false)
            break;
    }


}

static void merge(int[] arr, int l, int m, int r)
{

    int n1 = m - l + 1;
    int n2 = r - m;

    int[] L = new int[n1];
    int[] R = new int[n2];
    int i, j;

    for (i = 0; i < n1; ++i)
        L[i] = arr[l + i];
    for (j = 0; j < n2; ++j)
        R[j] = arr[m + 1 + j];

    i = 0;
    j = 0;

    int k = l;
    while (i < n1 && j < n2)
    {
        if (L[i] <= R[j])
        {
            arr[k] = L[i];
            i++;
        }
        else
        {
            arr[k] = R[j];
            j++;
        }
        k++;
    }

    while (i < n1)
    {
        arr[k] = L[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        arr[k] = R[j];
        j++;
        k++;
    }
}

// Main function that sorts arr[l..r] using merge()
static void mergeSort(int[] arr, int l, int r)
{

    if (l < r)
    {

        // Find the middle point
        int m = l + (r - l) / 2;

        // Sort first and second halves
        mergeSort(arr, l, m);
        mergeSort(arr, m + 1, r);

        // Merge the sorted halves
        merge(arr, l, m, r);
    }
}

// quick sort
static int partition(int[] arr, int low, int high)
{

    // choose the pivot
    int pivot = arr[high];

    // index of smaller element and indicates 
    // the right position of pivot found so far
    int i = low - 1;

    
    // traverse arr[low..high] and move all smaller
    // elements to the left side. Elements from low to 
    // i are smaller after every iteration
    for (int j = low; j <= high - 1; j++)
    {

        if (arr[j] < pivot)
        {
            i++;
            swap(arr, i, j);
            
        }
    }

    // move pivot after smaller elements and
    // return its position
    swap(arr, i + 1, high);
    return i + 1;
}

// swap function
static void swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

// The QuickSort function implementation
static void quickSort(int[] arr, int low, int high)
{
    if (low >= high)
    {
        return;
    }
        // pi is the partition return index of pivot
        int pi = partition(arr, low, high);

        // recursion calls for smaller elements
        // and greater or equals elements
        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    
}



// function
static int[] GenerateRandomArray(int length, int minValue, int maxValue)
{
    Random rand = new Random();
    int[] array = new int[length];

    for (int i = 0; i < length; i++)
    {
        array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
    }

    return array;
}

static int[] GenerateSortedArray(int length)
{
    int[] arr = new int[length];
    for (int i = 0; i < length; i++)
    {
        arr[i] = i + 1;
    }
    return arr;
}

static int[] GenerateReverseSortedArray(int length)
{
    int[] arr = new int[length];
    for (int i = 0; i < length; i++)
    {
        arr[i] = length - i;
    }
    return arr;
}

static int[] GeneratePartiallySortedArray(int length)
{
    int[] arr = new int[length];
    Random rand = new Random();

    int firstThirdEnd = length / 3;
    int secondThirdEnd = 2 * (length / 3);

    for (int i = 0; i < firstThirdEnd; i++)
    {
        arr[i] = i + 1;
    }

    int descendingValue = firstThirdEnd; 
    for (int i = firstThirdEnd; i < secondThirdEnd; i++)
    {
        arr[i] = descendingValue;
        descendingValue--; 
    }

    for (int i = secondThirdEnd; i < length; i++)
    {
        arr[i] = rand.Next(1, length + 1);
    }

    return arr;
}


static void DisplayRuntime(Stopwatch stopwatch)
{
    TimeSpan ts = stopwatch.Elapsed;

    // Format and display the TimeSpan value.
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("Time Taken: " + elapsedTime);
}



