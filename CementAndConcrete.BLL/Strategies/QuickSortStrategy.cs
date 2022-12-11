using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Strategies.Base;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Strategies
{
    /// <summary>
    ///     Class implements a sorting strategy using the quick sort approach.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class QuickSortStrategy : BaseStrategy<ListingItem<BaseModel>>, IAlgorithmStrategy
    {
        /// <summary>
        ///     Performs sorting of the incoming collection by the "Quick" method.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        public IEnumerable<ListingItem<BaseModel>> SortCollection(
            IEnumerable<ListingItem<BaseModel>> unsortedCollection)
        {
            this.SetCollection(unsortedCollection);

            this.QuickSort(0, this.Items.Count - 1);

            return this.Items;
        }

        /// <summary>
        ///     Splitting: Redistributing elements in an array so that elements smaller than the pivot are placed before the
        ///     selected one,
        ///     and those greater than or equal to the selected one are placed after..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="left">Contains left index</param>
        /// <param name="right">Contains right index</param>
        private void QuickSort(int left, int right)
        {
            while (true)
            {
                if (left >= right)
                {
                    return;
                }

                int pivot = this.Sorting(left, right);
                this.QuickSort(left, pivot - 1);
                left = pivot + 1;
            }
        }

        /// <summary>
        ///     Performs sorting of the incoming collection by the "Quick" method.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="left">Contains left index</param>
        /// <param name="right">Contains right index its pivot</param>
        /// <returns>New pivot index</returns>
        private int Sorting(int left, int right)
        {
            int pointer = left;

            for (int i = left; i <= right; i++)
            {
                if (this.Compare(this.Items[i], this.Items[right]) != -1)
                {
                    continue;
                }

                this.Swap(pointer, i);
                pointer++;
            }

            this.Swap(pointer, right);

            return pointer;
        }
    }
}