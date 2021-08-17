using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(isInclude(new int[] {}, new int[] {}));
        Console.WriteLine(isInclude(new int[] {1, 2, 3, 3, 5, 7, 9, 11}, new int[] {}));
        Console.WriteLine(isInclude(new int[] {1, 2, 3, 3, 5, 7, 9, 11}, new int[] {3, 5, 7}));
        Console.WriteLine(isInclude(new int[] {1, 2, 3, 3, 5, 7, 9, 11}, new int[] {4, 5, 7}));
    }

    public static bool isInclude(int[] array, int[] subarray)
    {
        // Проверяем крайние значения длин массивов
        if (array.Length == 0)
        {
            return false;
        }
        if (subarray.Length == 0)
        {
            return true;
        }

        // Двоичный поиск первого элемента подмассива в массиве (O(log(n)))
        int left = -1;
        int right = array.Length;
        int middle = 0;
        
        while (left < right - 1)
        {
            middle = (left + right) / 2;

            if (array[middle] < subarray[0]) 
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }

        // Учитываем одинаковые элементы
        int i = 0, j = 0;
        int offset = 0;

        while (right+i < array.Length && array[right] == array[right+i])
        {
            i++;
        }
        while (j < subarray.Length && subarray[0] == subarray[j])
        { 
            j++;
        }

        if (j > i)
        {
            return false;
        }

        offset = i - j;

        for (i = 0; i < subarray.Length; i++)
        {
            if (right+i+offset >= array.Length || array[right+i+offset] != subarray[i])
            {
                return false;
            }
        }
        return true;

        // Сложность по времени: O(log(n) + m)
        // В худшем случае: O(n) (если в основном массиве все элементы одинаковые)
    }
}
