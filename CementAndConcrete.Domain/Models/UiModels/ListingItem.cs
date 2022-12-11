using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models.UiModels
{
    /// <summary>
    ///     Wrapper class over BaseModel.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public class ListingItem<T> : IComparable where T : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ListingItem{T}" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="element">Contains BaseModel object</param>
        public ListingItem(T element)
        {
            this.Element = element;
            this.TypeOfElement = element.GetType();
            this.Name = element.Name;
        }

        /// <summary>
        ///     Gets  or sets the name of the BaseModel object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The name of the BaseModel object</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the BaseModel object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The BaseModel object</value>
        public T Element { get; set; }

        /// <summary>
        ///     Gets or sets the type of BaseModel object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The BaseModel object</value>
        public Type TypeOfElement { get; set; }

        /// <summary>
        ///     Compare ListingItem object for its name in alphabetic.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="other"></param>
        /// <returns>Returns 0 is equals, 1 if older, -1 if younger</returns>
        public int CompareTo(object? other)
        {
            if (other == null)
            {
                throw new NullReferenceException("other");
            }

            var otherElement = other as ListingItem<BaseModel>;
            string otherName = otherElement!.Name;
            int result = this.Name.CompareTo(otherName);

            return result;
        }
    }
}