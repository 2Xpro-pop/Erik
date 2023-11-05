using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Erik.View;
using Erik.ViewModels;
using ReactiveUI;

namespace Erik;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        router.Router = new RoutingState();
        router.ViewLocator = new RouterViewLocator();
    }

    private void TitleMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ClearRouterByClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 1)
        {
            router.Router.NavigationStack.Clear();
        }
    }

    private class RouterViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => new SortPresenter()
        {
            DataContext = viewModel,
        };
    }

    private void HybridSortPresent(object sender, RoutedEventArgs e)
    {
        router.Router.Navigate.Execute(new IntroSortViewModel()).Subscribe();
    }

    private void HybridSortPresent(object sender, MouseButtonEventArgs e)
    {
        HybridSortPresent(sender, (RoutedEventArgs)e); ;
    }

    private void PancakeSortPresent(object sender, RoutedEventArgs e)
    {
        router.Router.Navigate.Execute(new PancakeSortViewModel()).Subscribe();
    }

    private void PancakeSortPresent(object sender, MouseButtonEventArgs e)
    {
        PancakeSortPresent(sender, (RoutedEventArgs)e);
    }

    private void ShakerSortPresent(object sender, RoutedEventArgs e)
    {
        router.Router.Navigate.Execute(new CocktailShakerSortViewModel()).Subscribe();
    }

    private void ShakerSortPresent(object sender, MouseButtonEventArgs e)
    {
        ShakerSortPresent(sender, (RoutedEventArgs)e);
    }
}
