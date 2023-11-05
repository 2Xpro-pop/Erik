using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erik.ViewModels;

public class CocktailShakerSortViewModel : ArrSortViewModel
{
    public CocktailShakerSortViewModel()
    {
        Name = "Сортировка Шейкерная с вставками";
        Description = "Сортировка Шейкерная (Cocktail Shaker Sort), также известная как сортировка перекачиванием, является вариацией сортировки пузырьком. Дополнительно, мы можем использовать сортировку вставками для улучшения производительности в некоторых случаях";
        Code = @"public override void SortArray(int[] array)
{
    int left = 0;
    int right = array.Length - 1;

    while (left < right)
    {
        // Сортировка вправо (аналог сортировки пузырьком)
        for (int i = left; i < right; i++)
        {
            if (array[i] > array[i + 1])
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }
        right--;

        // Сортировка влево (аналог сортировки пузырьком)
        for (int i = right; i > left; i--)
        {
            if (array[i] < array[i - 1])
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }
        left++;
        
    }

    // Завершаем сортировку вставкой
    InsertionSort(array);
}

private void InsertionSort(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int key = array[i];
        int j = i - 1;

        while (j >= 0 && array[j] > key)
        {
            (array[j + 1], array[j]) = (array[j], array[j + 1]);
            j--;
        }

    }
}";
    }

    public override void SortArray(int[] array)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            // Сортировка вправо (аналог сортировки пузырьком)
            for (int i = left; i < right; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
            right--;

            // Сортировка влево (аналог сортировки пузырьком)
            for (int i = right; i > left; i--)
            {
                if (array[i] < array[i - 1])
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                }
            }
            left++;
        
        }

        // Завершаем сортировку вставкой
        InsertionSort(array);
    }

    private void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                (array[j + 1], array[j]) = (array[j], array[j + 1]);
                j--;
            }

        }
    }
}
