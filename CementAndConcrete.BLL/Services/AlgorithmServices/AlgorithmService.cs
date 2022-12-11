using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Strategies;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Services.AlgorithmServices
{
    /// <summary>
    ///     Class for dependency injection Service AlgorithmService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class AlgorithmService : IAlgorithmService
    {
        /// <summary>
        ///     Contains algorithm updateStrategy.
        /// </summary>
        private IAlgorithmStrategy? strategy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AlgorithmService" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public AlgorithmService()
        {
            this.strategy = new QuickSortStrategy();
        }

        /// <summary>
        ///     The method specifies what type of updateStrategy will be used to sort records.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="updateStrategy">Contains update updateStrategy</param>
        public void SetStrategy(IAlgorithmStrategy? updateStrategy)
        {
            if (updateStrategy != null && updateStrategy != this.strategy)
            {
                this.strategy = updateStrategy;
            }
        }

        /// <summary>
        ///     Performs sorting of the incoming collection.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        /// <returns>Sorted collection</returns>
        public IEnumerable<ListingItem<BaseModel>> Execute(IEnumerable<ListingItem<BaseModel>> unsortedCollection)
            => this.strategy != null ? this.strategy.SortCollection(unsortedCollection) : unsortedCollection;
    }
}