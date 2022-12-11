using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Strategies.Base;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Strategies
{
    /// <summary>
    ///     Class implements a sorting strategy using the insert sort approach.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class InsertSortStrategy : BaseStrategy<ListingItem<BaseModel>>, IAlgorithmStrategy
    {
        /// <summary>
        ///     Performs sorting of the incoming collection by the "Insert" method.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        public IEnumerable<ListingItem<BaseModel>> SortCollection(
            IEnumerable<ListingItem<BaseModel>> unsortedCollection)
        {
            this.SetCollection(unsortedCollection);

            for (int i = 1; i < this.Items.Count; i++)
            {
                var temp = this.Items[i];
                int counter = i;

                while (counter > 0 && this.Compare(temp, this.Items[counter - 1]) == -1)
                {
                    this.Swap(counter, counter - 1);
                    counter--;
                }

                this.Items[counter] = temp;
            }

            return this.Items;
        }
    }
}