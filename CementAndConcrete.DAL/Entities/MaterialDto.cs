using CementAndConcrete.DAL.Entities.Base;

namespace CementAndConcrete.DAL.Entities
{
    /// <summary>
    ///     Class MaterialDto model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MaterialDto : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the name of the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The name of the MaterialDto object</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the amount of the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The amount of the MaterialDto object</value>
        public int Amount { get; set; }

        /// <summary>
        ///     Gets or sets the price of the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The price of the MaterialDto object</value>
        public decimal Price { get; set; }
    }
}