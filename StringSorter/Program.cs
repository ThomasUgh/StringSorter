using System;

class StringSorter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wählen Sie eine Sortiermethode:");
        Console.WriteLine("1 - Quick Sort");
        Console.WriteLine("2 - Bubble Sort");
        Console.WriteLine("3 - Selection Sort");
        int method = int.Parse(Console.ReadLine());

        // Zufälligen String generieren
        string inputString = GenerateRandomString();

        // String sortieren
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
                Console.WriteLine("Ungültige Auswahl");
                return;
        }

        Console.WriteLine("Sortierte Zeichenfolge: " + inputString);
    }

    static string GenerateRandomString()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        int length = random.Next(15, 25);
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    static string QuickSort(string s)
    {
        char[] chars = s.ToCharArray();
        QuickSort(chars, 0, chars.Length - 1);
        return new string(chars);
    }

    static void QuickSort(char[] chars, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(chars, left, right);
            QuickSort(chars, left, pivotIndex - 1);
            QuickSort(chars, pivotIndex + 1, right);
        }
    }

    static int Partition(char[] chars, int left, int right)
    {
        char pivot = chars[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (chars[j] <= pivot)
            {
                i++;
                Swap(chars, i, j);
            }
        }

        Swap(chars, i + 1, right);
        return i + 1;
    }

    static string BubbleSort(string s)
    {
        char[] chars = s.ToCharArray();

        for (int i = 0; i < chars.Length - 1; i++)
        {
            for (int j = 0; j < chars.Length - 1 - i; j++)
            {
                if (chars[j] > chars[j + 1])
                {
                    Swap(chars, j, j + 1);
                }
            }
        }

        return new string(chars);
    }
