using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;

namespace Erik.ViewModels;

public class PancakeSortViewModel : ArrSortViewModel
{
    public PancakeSortViewModel(): base()
    {
        Name = "Блинная сортировка";
        Description = "Сортировка блинами (Pancake Sorting) - это необычный алгоритм сортировки, который пытается упорядочить элементы массива путем поворота порции элементов вокруг определенной точки. Каждый элемент массива, начиная с последнего и заканчивая первым, пытается подняться вверх и \"упасть\" на свое место в отсортированной последовательности";
        Code = @"public override void SortArray(int[] array)
{
    for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
    {
        //получаем позицию максимального элемента подмассива
        var indexOfMax = IndexOfMax(array, subArrayLength);
        if (indexOfMax != subArrayLength)
        {
            //переворот массива до индекса максимального элемента
            //максимальный элемент подмассива расположится вначале
            Flip(array, indexOfMax);
            //переворот всего подмассива
            Flip(array, subArrayLength);
        }
    }
}

private int IndexOfMax(int[] array, int n)
{
    var result = 0;
    for (var i = 1; i <= n; ++i)
    {
        if (array[i] > array[result])
        {
            result = i;
        }
    }

    return result;
}

//метод для переворота массива
private void Flip(int[] array, int end)
{
    for (var start = 0; start < end; start++, end--)
    {
        (array[end], array[start]) = (array[start], array[end]);
    }
}";
    }
    public override void SortArray(int[] array)
    {
        for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
        {
            //получаем позицию максимального элемента подмассива
            var indexOfMax = IndexOfMax(array, subArrayLength);
            if (indexOfMax != subArrayLength)
            {
                //переворот массива до индекса максимального элемента
                //максимальный элемент подмассива расположится вначале
                Flip(array, indexOfMax);
                //переворот всего подмассива
                Flip(array, subArrayLength);
            }
        }
    }

    private int IndexOfMax(int[] array, int n)
    {
        var result = 0;
        for (var i = 1; i <= n; ++i)
        {
            if (array[i] > array[result])
            {
                result = i;
            }
        }

        return result;
    }

    //метод для переворота массива
    private void Flip(int[] array, int end)
    {
        for (var start = 0; start < end; start++, end--)
        {
            (array[end], array[start]) = (array[start], array[end]);
        }
    }
}
