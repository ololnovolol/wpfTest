using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class Table model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class Table : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Table" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="category">Contains enum TableCategory value</param>
        public Table(TableCategories category)
        {
            this.Category = category;
        }

        /// <summary>
        ///     Gets the name of category object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The TableCategory enum value</value>
        public TableCategories Category { get; }
    }
}