using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Services.AlgorithmServices;
using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.WPF.Models
{
    /// <summary>
    ///     Model class for MainViewModel.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MainModel
    {
        /// <summary>
        ///     Stores the table management service from the sort algorithms.
        /// </summary>
        private readonly IAlgorithmService algorithmService;

        /// <summary>
        ///     Stores the builder management service from the database.
        /// </summary>
        private readonly IBuilderService builderService;

        /// <summary>
        ///     Stores the Customers management service from the database.
        /// </summary>
        private readonly ICustomersService customerService;

        /// <summary>
        ///     Stores the material management service from the database.
        /// </summary>
        private readonly IMaterialService materialService;

        /// <summary>
        ///     Stores the order management service from the database.
        /// </summary>
        private readonly IOrderService orderService;

        /// <summary>
        ///     Stores the table management service from the database.
        /// </summary>
        private readonly ITableService tableService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainModel" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="tableService">Contains service of menage Table objects</param>
        /// <param name="customerService">Contains service of menage Customers objects</param>
        /// <param name="orderService">Contains service of menage Order objects</param>
        /// <param name="materialService">Contains service of menage Material objects</param>
        /// <param name="builderService">Contains service of menage Builder objects</param>
        public MainModel(
            ITableService tableService,
            ICustomersService customerService,
            IOrderService orderService,
            IMaterialService materialService,
            IBuilderService builderService)
        {
            this.tableService = tableService;
            this.customerService = customerService;
            this.orderService = orderService;
            this.materialService = materialService;
            this.builderService = builderService;
            algorithmService = new AlgorithmService();
        }

        /// <summary>
        ///     Gets ListingItem collection of BaseModel elements from the database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="table">Contains the nae of current table</param>
        /// <returns>Returns ListingItem collection</returns>
        public ObservableCollection<ListingItem<BaseModel>> GetListingItemCollection(Table table)
        {
            var result = new ObservableCollection<ListingItem<BaseModel>>();

            if (table is { Category: TableCategories.Default })
            {
                return result;
            }

            var service = ChooseNeedRecordsCollection(table.Category);

            foreach (BaseModel record in service)
            {
                result.Add(new ListingItem<BaseModel>(record));
            }

            return result;
        }

        /// <summary>
        ///     Sort collection of ListingItem elements from the database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="records">Contains unsorted ListingItem collection</param>
        /// <param name="selectedAlgorithmItem">Contains selected by user sorting algorithm</param>
        /// <returns>Returns sorted ListingItem collection</returns>
        public ObservableCollection<ListingItem<BaseModel>> SortListingItemCollection(
            IEnumerable<ListingItem<BaseModel>> records,
            Algorithms selectedAlgorithmItem)
        {
            algorithmService
                .SetStrategy(
                    new StrategyPicker(selectedAlgorithmItem)
                        .ChooseStrategyAccordingSelectedAlgorithm());

            var sortedCollection = algorithmService.Execute(records);

            var result = new ObservableCollection<ListingItem<BaseModel>>();

            foreach (var record in sortedCollection)
            {
                result.Add(record);
            }

            return result;
        }

        /// <summary>
        ///     Gets all table names from the database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>Returns a list of table names from the database the Table type.</returns>
        public List<Table> GetTables()
        {
            var tables = tableService.GetAll().ToList();

            return tables ?? new List<Table>();
        }

        public void UpdateModel(BaseModel item, Type itemType)
        {
            UpdateNeedRecord(itemType, item);
        }

        /// <summary>
        ///     Determiner the required List of objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="tableName">Contains name of entity category</param>
        /// <returns>Returns object collection of BaseModel objects</returns>
        private IEnumerable<BaseModel> ChooseNeedRecordsCollection(TableCategories tableName)
        {
            return tableName switch
            {
                TableCategories.Customers => customerService.GetAll(),
                TableCategories.Builders => builderService.GetAll(),
                TableCategories.Orders => orderService.GetAll(),
                TableCategories.Materials => materialService.GetAll(),
                TableCategories.Default => throw new ArgumentOutOfRangeException(nameof(tableName), tableName, null),
                _ => throw new ArgumentOutOfRangeException(nameof(tableName), tableName, null)
            };
        }

        /// <summary>
        ///     Determiner the required List of objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="recordType">Contains name of entity category</param>
        /// <param name="updateRecord"></param>
        /// <returns>Returns object collection of BaseModel objects</returns>
        private void UpdateNeedRecord(Type recordType, BaseModel updateRecord)
        {
            //if (recordType.iscl) throw new ArgumentNullException();

            //recordType switch
            //{
            //    //Customer => customerService.Update(typeof(recordType)updateRecord),
            //    //Builder => builderService.Update(typeof(recordType)updateRecord),
            //    //Order => orderService.Update(typeof(recordType)updateRecord),
            //    //Material => materialService.Update(typeof(recordType)updateRecord),
            //    //_ => throw new ArgumentOutOfRangeException(nameof(recordType), recordType, null)
            //};
        }
    }
}