using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Strategies.Base;
using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Strategies
{
    /// <summary>
    ///     Class implements a sorting strategy using the merge sort approach.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MergeSortStrategy : BaseStrategy<ListingItem<BaseModel>>, IAlgorithmStrategy
    {
        /// <summary>
        ///     Performs sorting of the incoming collection by the "Merge" method.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="unsortedCollection">Contains incoming unsorted collection</param>
        public IEnumerable<ListingItem<BaseModel>> SortCollection(
            IEnumerable<ListingItem<BaseModel>> unsortedCollection)
        {
            this.SetCollection(unsortedCollection);

            return this.SplitSort(this.Items);
        }

        /// <summary>
        ///     Divides a collection into sub-collections.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="items">incoming unsorted collection</param>
        /// <returns>sorted collection</returns>
        private List<ListingItem<BaseModel>> SplitSort(List<ListingItem<BaseModel>> items)
        {
            if (items.Count == 1)
            {
                return items;
            }

            int mid = items.Count / 2;

            var left = items.Take(mid).ToList();
            var right = items.Skip(mid).ToList();

            return this.Merge(this.SplitSort(left), this.SplitSort(right));
        }

        /// <summary>
        ///     Concatenates sorted sub-collections into one sorted collection.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="left">left sub-collection</param>
        /// <param name="right">right sub-collection</param>
        /// <returns>Union sorted collection</returns>
        private List<ListingItem<BaseModel>> Merge(
            IReadOnlyList<ListingItem<BaseModel>> left,
            IReadOnlyList<ListingItem<BaseModel>> right)
        {
            int length = left.Count + right.Count;
            int leftPointer = 0;
            int rightPointer = 0;

            var result = new List<ListingItem<BaseModel>>(length);

            for (int i = 0; i < length; i++)
            {
                if (leftPointer < left.Count && rightPointer < right.Count)
                {
                    if (this.Compare(left[leftPointer], right[rightPointer]) == -1)
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                }
                else
                {
                    if (rightPointer < right.Count)
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                    else
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                }
            }

            return result;
        }
    }
}