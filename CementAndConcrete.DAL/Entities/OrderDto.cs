using CementAndConcrete.DAL.Entities.Base;

namespace CementAndConcrete.DAL.Entities
{
    /// <summary>
    ///     Class OrderDto model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class OrderDto : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the Customers identifier linked with OrderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Customers identifier linked with OrderDto object</value>
        public Guid CustomerId { get; set; }

        /// <summary>
        ///     Gets or sets the start date of the OrderDto.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The start date of the OrderDto object</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date of the OrderDto.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The End date of the OrderDto</value>
        public DateTime EndDAte { get; set; }

        /// <summary>
        ///     Gets or sets the total price of the OrderDto.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The total price of the OrderDto</value>
        public decimal TotalPrice { get; set; }
    }
}