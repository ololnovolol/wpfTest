using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Interfaces
{
    /// <summary>
    ///     Interface for dependency injection Service AlgorithmService.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IAlgorithmService
    {
        /// <summary>
        ///     The method specifies what type of updateStrategy will be used to sort records.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="updateStrategy">Contains new Strategy</param>
        public void SetStrategy(IAlgorithmStrategy? updateStrategy);

        /// <summary>
        ///     Incoming collection sorted according to current strategy.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        /// <returns>Performs sorting of the incoming collection</returns>
        public IEnumerable<ListingItem<BaseModel>> Execute(IEnumerable<ListingItem<BaseModel>> unsortedCollection);
    }
}