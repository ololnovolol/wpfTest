using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Interfaces
{
    /// <summary>
    ///     Interface for dependency injection Service AlgorithmStrategy.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IAlgorithmStrategy
    {
        /// <summary>
        ///     Performs sorting of the incoming collection.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        /// <returns>The same but Sorted Collection</returns>
        IEnumerable<ListingItem<BaseModel>> SortCollection(IEnumerable<ListingItem<BaseModel>> unsortedCollection);
    }
}