using System;
using static System.Console;

class StringSorter
{
    static void Main(string[] args)
    {
        WriteLine("Wählen Sie eine Sortiermethode:");
        WriteLine("1 - Quick Sort");
        WriteLine("2 - Bubble Sort");
        WriteLine("3 - Selection Sort");
        var method = int.Parse(ReadLine()!);

        // Zufälligen String generieren
        var inputString = GenerateRandomString();
        
        switch (method)
        {
            case 1:
                inputString = QuickSort(inputString);
                break;
            case 2:
                inputString = BubbleSort(inputString);
                break;
            case 3:
                inputString = SelectionSort(inputString);
                break;
            default:
                WriteLine("Ungültige Auswahl");
                return;
        }

        WriteLine("Sortierte Zeichenfolge: " + inputString);
    }

    static string GenerateRandomString()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var length = random.Next(15, 25); //Generierungslänge
        var stringChars = new char[length];
        for (var i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    static string QuickSort(string s)
    {
        var chars = s.ToCharArray();
        QuickSort(chars, 0, chars.Length - 1);
        return new string(chars);
    }

    private static void QuickSort(char[] chars, int left, int right)
    {
        if (left >= right) return;
        var pivotIndex = Partition(chars, left, right);
        QuickSort(chars, left, pivotIndex - 1);
        QuickSort(chars, pivotIndex + 1, right);
    }

    private static int Partition(char[] chars, int left, int right)
    {
        var pivot = chars[right];
        var i = left - 1;

        for (var j = left; j < right; j++)
        {
            if (chars[j] > pivot) continue;
            i++;
            Swap(chars, i, j);
        }

        Swap(chars, i + 1, right);
        return i + 1;
    }

    private static string BubbleSort(string s)
    {
        var chars = s.ToCharArray();

        for (var i = 0; i < chars.Length - 1; i++)
        {
            for (var j = 0; j < chars.Length - 1 - i; j++)
            {
                if (chars[j] <= chars[j + 1]) continue;
                Swap(chars, j, j + 1);
            }
        }

        return new string(chars);
    }

    private static string SelectionSort(string s)
    {
        var chars = s.ToCharArray();

        for (var i = 0; i < chars.Length - 1; i++)
        {
            var minIndex = i;

            for (var j = i + 1; j < chars.Length; j++)
            {
                if (chars[j] >= chars[minIndex]) continue;
                minIndex = j;
            }

            if (minIndex == i) continue;
            Swap(chars, i, minIndex);
        }

        return new string(chars);
    }

    private static void Swap(char[] chars, int i, int j)
    {
        (chars[i], chars[j]) = (chars[j], chars[i]);
    }
}