using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Erik.ViewModels;

public abstract class ArrSortViewModel : ReactiveObject, IRoutableViewModel
{
    public ArrSortViewModel(IScreen hostScreen = null!)
    {
        HostScreen = hostScreen;
        UrlPathSegment = $"/{this.GetType().Name}";

        Array = "11, 2, 6, 8, 73, 51, 96, 4, 38, 81";
        SortCommand = ReactiveCommand.Create(() =>
        {
            var array = Array.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => int.Parse(x))
                             .ToArray();
            Result = string.Empty;
            SortArray(array);
            Result = string.IsNullOrWhiteSpace(Result) ? $"Отсортированный массив {string.Join(",", array)}" : Result;
        });
    }

    public string Name
    {
        get; set;
    }

    public string Description
    {
        get; set;
    }

    public string Code
    {
        get; set;
    }

    public string? UrlPathSegment
    {
        get;
    }

    public IScreen HostScreen
    {
        get;
    }

    [Reactive]
    public string Result
    {
        get; protected set;
    }

    [Reactive]
    public string Array
    {
        get; set;
    } = string.Empty;

    public ICommand SortCommand
    {
        get;
    }

    public abstract void SortArray(int[] array);
}
