using System.Collections.ObjectModel;
using System.Windows.Input;
using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;
using CementAndConcrete.WPF.Commands;
using CementAndConcrete.WPF.Models;
using CementAndConcrete.WPF.ViewModel.Base;

namespace CementAndConcrete.WPF.ViewModel
{
    /// <summary>
    ///     View model of mainWindow view.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        ///     model object for MainViewModel.
        /// </summary>
        private readonly MainModel mainModelItem;

        /// <summary>
        ///     Stores the collection of available algorithms.
        /// </summary>
        private ObservableCollection<AlgorithmModel> algorithms;

        /// <summary>
        ///     Stores the collection of available ListingItem objects.
        /// </summary>
        private ObservableCollection<ListingItem<BaseModel>> listingCollection;

        /// <summary>
        ///     Stores the user's selected AlgorithmModel object.
        /// </summary>
        private AlgorithmModel? selectableAlgorithm;

        /// <summary>
        ///     Stores the user's selected ListingItem object.
        /// </summary>
        private ListingItem<BaseModel>? selectableListingData;

        /// <summary>
        ///     Stores the user's selected Table object.
        /// </summary>
        private Table? selectedTable;

        /// <summary>
        ///     Stores a collection of Table objects in a database.
        /// </summary>
        private ObservableCollection<Table> tables;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindowViewModel" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="mainModel">Contains MainModel object</param>
        public MainWindowViewModel(MainModel mainModel)
        {
            mainModelItem = mainModel;

            RefreshCommand = new ActionCommand(Refresh);
            SaveCommand = new ActionCommand(Save);
            SortCommand = new ActionCommand(ExecuteSortAlgorithm);

            tables = new ObservableCollection<Table>(mainModelItem.GetTables());

            algorithms = new ObservableCollection<AlgorithmModel>
            {
                new(Algorithms.Quick), new(Algorithms.Merge), new(Algorithms.Insert)
            };

            listingCollection = new ObservableCollection<ListingItem<BaseModel>>();
        }

        /// <summary>
        ///     Gets or sets a list of ListingItem objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>List of ListingItem objects.</value>
        public ObservableCollection<ListingItem<BaseModel>> AllListings
        {
            get => listingCollection;
            set
            {
                listingCollection = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a selected by user item of ListingItem object list.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>Selected by user item of ListingItem object list.</value>
        public ListingItem<BaseModel>? SelectedListingData
        {
            get => selectableListingData;
            set
            {
                selectableListingData = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a list of Table objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>List of Table objects.</value>
        public ObservableCollection<Table> AllTables
        {
            get => tables ??= new ObservableCollection<Table>(mainModelItem.GetTables());
            set
            {
                tables = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a selected by user item of Table object list.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>Selected by user item of Table object list.</value>
        public Table? SelectedTableData
        {
            get => selectedTable;
            set
            {
                selectedTable = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a list of AlgorithmModel object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>List of AlgorithmModel  objects.</value>
        public ObservableCollection<AlgorithmModel> AllAlgorithms
        {
            get => algorithms;
            set
            {
                algorithms = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a selected user item of AlgorithmModel object list.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>Selected by user item of AlgorithmModel object list.</value>
        public AlgorithmModel? SelectedAlgorithmData
        {
            get => selectableAlgorithm;
            set
            {
                selectableAlgorithm = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets a SortCommand.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The ICommand object.</value>
        public ICommand RefreshCommand { get; }

        /// <summary>
        ///     Gets a SortCommand.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The ICommand object.</value>
        public ICommand SaveCommand { get; }

        /// <summary>
        ///     Gets a SortCommand.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The ICommand object.</value>
        public ICommand SortCommand { get; }

        /// <summary>
        ///     Calls a command to load data into the component listing.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void Refresh()
        {
            if (SelectedTableData is { Category: TableCategories.Default })
            {
                return;
            }

            if (SelectedTableData != null)
            {
                AllListings = mainModelItem.GetListingItemCollection(SelectedTableData);
            }

            OnPropertyChanged();
        }

        /// <summary>
        ///     Invokes the command to save changed data by the user.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void Save()
        {
            SaveInputData();
            ClearSelected();
            OnPropertyChanged();
        }

        /// <summary>
        ///     Invokes the command to apply the selected algorithm.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void ExecuteSortAlgorithm()
        {
            if (SelectedAlgorithmData is null || AllListings.Count <= 0)
            {
                return;
            }

            var sortedListingCollection = mainModelItem.SortListingItemCollection(
                AllListings,
                SelectedAlgorithmData.Algorithms);

            AllListings = sortedListingCollection;

            OnPropertyChanged();
        }

        /// <summary>
        ///     Clear all selected by user data.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        private void ClearSelected()
        {
            selectedTable = null;
            selectableAlgorithm = null;
            selectableListingData = null;
            SelectedAlgorithmData = null;
            SelectedTableData = null;
            SelectedListingData = null;
            AllListings = new ObservableCollection<ListingItem<BaseModel>>();

            OnPropertyChanged();
        }

        /// <summary>
        ///     Save changed selected data by user.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        private void SaveInputData()
        {
            if (SelectedListingData != null || selectableListingData != null)
            {
                mainModelItem.UpdateModel(SelectedListingData!.Element, selectableListingData!.TypeOfElement);
            }
            else
            {
                return;
            }

            OnPropertyChanged();
        }
    }
}