﻿using System;

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
