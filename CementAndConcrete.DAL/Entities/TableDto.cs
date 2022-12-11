using CementAndConcrete.DAL.Entities.Base;
using CementAndConcrete.Domain.Enums;

namespace CementAndConcrete.DAL.Entities
{
    /// <summary>
    ///     Class TableDto model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class TableDto : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the TableDto object
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>Name of TableDto object</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets the name of category object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The TableCategory object</value>
        public TableCategories Category { get; set; }
    }
}