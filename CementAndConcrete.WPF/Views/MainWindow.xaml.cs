using System;
using System.Windows.Controls;
using CementAndConcrete.Domain.Models;
using CementAndConcrete.WPF.ViewModel;
using CementAndConcrete.WPF.Views.DataControls;

namespace CementAndConcrete.WPF.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public partial class MainWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="viewModel">Contains MainViewModel object</param>
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        /// <summary>
        ///     Changes the logic of displaying the components of the details window based on the selected listbox elements.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="sender">Contains sender object</param>
        /// <param name="e">Contains selection event</param>
        private void OnSelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsPanel.Children.Clear();

            if (DataContext is not MainWindowViewModel vm)
            {
                throw new NullReferenceException("View Model is null");
            }

            UserControl control = new();

            if (vm.SelectedListingData is null)
            {
                return;
            }

            if (vm.SelectedListingData!.TypeOfElement == typeof(Order))
            {
                control = new OrderControl();
            }
            else if (vm.SelectedListingData!.TypeOfElement == typeof(Material))
            {
                vm.SelectedListingMaterial = (Material)vm.SelectedListingData.Element;
                control = new MaterialControl();
            }
            else if (vm.SelectedListingData!.TypeOfElement == typeof(Builder))
            {
                control = new BuilderControl();
            }
            else if (vm.SelectedListingData!.TypeOfElement == typeof(Customer))
            {
                control = new CustomerControl();
            }

            control.SetValue(Grid.ColumnProperty, 2);
            DetailsPanel.Children.Add(control);
        }
    }
}