using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erik.ViewModels;

public class IntroSortViewModel : ArrSortViewModel
{

    public IntroSortViewModel() : base() 
    {
        Name = "Гибридная сортировка";
        Description = "Гибридная сортировка (Introsort) комбинирует быструю сортировку (Quicksort), сортировку кучей (Heapsort) и сортировку вставками (Insertion Sort) для эффективной сортировки больших массивов.";
        Code = @"public override void SortArray(int[] array)
{
    var maxDepth = 2 * (int)Math.Log(array.Length);
    IntroSort(array, 0, array.Length - 1, maxDepth);
}

private void IntroSort(int[] array, int left, int right, int maxDepth)
{
    if (left < right)
    {
        if (maxDepth == 0)
        {
            HeapSort(array, left, right);
        }
        else
        {
            var pivot = Partition(array, left, right);
            IntroSort(array, left, pivot - 1, maxDepth - 1);
            IntroSort(array, pivot + 1, right, maxDepth - 1);
        }
    }
}

private int Partition(int[] array, int left, int right)
{
    var pivot = array[right];
    var i = left - 1;

    for (var j = left; j < right; j++)
    {
        if (array[j] < pivot)
        {
            i++;
            (array[j], array[i]) = (array[i], array[j]);
        }
    }

    (array[right], array[i + 1]) = (array[i + 1], array[right]);
    return i + 1;
}

private void HeapSort(int[] array, int left, int right)
{
    var n = right - left + 1;

    for (var i = n / 2 - 1; i >= 0; i--)
        Heapify(array, n, i, left);

    for (var i = n - 1; i > 0; i--)
    {
        (array[left + i], array[left]) = (array[left], array[left + i]);

        Heapify(array, i, 0, left);
    }
}

private void Heapify(int[] array, int n, int i, int left)
{
    var largest = i;
    var leftChild = 2 * i + 1;
    var rightChild = 2 * i + 2;

    if (leftChild < n && array[left + leftChild] > array[left + largest])
        largest = leftChild;

    if (rightChild < n && array[left + rightChild] > array[left + largest])
        largest = rightChild;

    if (largest != i)
    {
        (array[left + largest], array[left + i]) = (array[left + i], array[left + largest]);
    }
}
";
    }

    public override void SortArray(int[] array)
    {
        var maxDepth = 2 * (int)Math.Log(array.Length);
        IntroSort(array, 0, array.Length - 1, maxDepth);
    }

    private void IntroSort(int[] array, int left, int right, int maxDepth)
    {
        if (left < right)
        {
            if (maxDepth == 0)
            {
                HeapSort(array, left, right);
            }
            else
            {
                var pivot = Partition(array, left, right);
                IntroSort(array, left, pivot - 1, maxDepth - 1);
                IntroSort(array, pivot + 1, right, maxDepth - 1);
            }
        }
    }

    private int Partition(int[] array, int left, int right)
    {
        var pivot = array[right];
        var i = left - 1;

        for (var j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        (array[right], array[i + 1]) = (array[i + 1], array[right]);
        return i + 1;
    }

    private void HeapSort(int[] array, int left, int right)
    {
        var n = right - left + 1;

        for (var i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i, left);

        for (var i = n - 1; i > 0; i--)
        {
            (array[left + i], array[left]) = (array[left], array[left + i]);

            Heapify(array, i, 0, left);
        }
    }

    private void Heapify(int[] array, int n, int i, int left)
    {
        var largest = i;
        var leftChild = 2 * i + 1;
        var rightChild = 2 * i + 2;

        if (leftChild < n && array[left + leftChild] > array[left + largest])
            largest = leftChild;

        if (rightChild < n && array[left + rightChild] > array[left + largest])
            largest = rightChild;

        if (largest != i)
        {
            (array[left + largest], array[left + i]) = (array[left + i], array[left + largest]);
        }
    }
}
