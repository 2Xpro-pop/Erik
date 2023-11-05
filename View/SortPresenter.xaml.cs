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
using Erik.ViewModels;
using ReactiveUI;

namespace Erik.View
{
    /// <summary>
    /// Логика взаимодействия для SortPresenter.xaml
    /// </summary>
    public partial class SortPresenter : UserControl, IViewFor<ArrSortViewModel>
    {
        public SortPresenter()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name == nameof(ViewModel) || e.Property.Name == nameof(DataContext))
            {
                var vm = (ArrSortViewModel)DataContext;
                textEditor.Text = vm.Code;
            }
        }
        public ArrSortViewModel? ViewModel
        {
            get;
            set;
        }
        object? IViewFor.ViewModel
        {
            get;
            set;
        }
    }
}
