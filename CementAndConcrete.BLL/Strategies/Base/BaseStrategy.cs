using CementAndConcrete.Domain.Models.Base;
using CementAndConcrete.Domain.Models.UiModels;

namespace CementAndConcrete.BLL.Strategies.Base
{
    /// <summary>
    ///     Class for introducing basic features to sorting algorithms.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public class BaseStrategy<T> where T : IComparable
    {
        /// <summary>
        ///     Initializes the empty new instance of the<cref> BaseStrategy</cref> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public BaseStrategy()
        {
            this.Items = new List<ListingItem<BaseModel>>();
        }

        /// <summary>
        ///     Gets or sets a collection to rearrange elements in it.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The first name of the ListingItem object</value>
        protected List<ListingItem<BaseModel>> Items { get; private set; }

        /// <summary>
        ///     Adds an input collection to the base.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="items">Contains an input collection</param>
        protected void SetCollection(IEnumerable<ListingItem<BaseModel>> items)
        {
            this.Items ??= new List<ListingItem<BaseModel>>();

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.Items.AddRange(items);
        }

        /// <summary>
        ///     Collection position exchange method.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="positionA">Contains first index of element</param>
        /// <param name="positionB">Contains second index of element</param>
        protected void Swap(int positionA, int positionB)
        {
            if (positionA >= this.Items.Count || positionB >= this.Items.Count
                                              || positionA < 0 || positionB < 0)
            {
                return;
            }

            (this.Items[positionA], this.Items[positionB]) = (this.Items[positionB], this.Items[positionA]);
        }

        /// <summary>
        ///     Compare incoming elements.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="firstValue">Contains first compare item</param>
        /// <param name="secondValue">Contains second compare item</param>
        /// <returns>Result of compare ListingItem object and Returns 0 is equals, 1 if older, -1 if younger</returns>
        protected int Compare(T firstValue, T secondValue) => firstValue.CompareTo(secondValue);
    }
}