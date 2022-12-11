using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class Order model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class Order : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Order" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="customerId">Contains CustomerId object to link him with Order object</param>
        /// <param name="startDate">Contains date value when order has been started</param>
        /// <param name="endDate">Contains date value when order has been ended</param>
        /// <param name="totalPrice">Contains decimal value of the Order object</param>
        public Order(Guid customerId, DateTime startDate, DateTime endDate, decimal totalPrice)
        {
            this.CustomerId = customerId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TotalPrice = totalPrice;
            this.Name = this.CustomerId.ToString()[..12] ?? string.Empty;
        }

        /// <summary>
        ///     Gets the Customers object to link him with Order object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Customers object</value>
        public Guid CustomerId { get; set; }

        /// <summary>
        ///     Gets the start date of the Order.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The start date of the Order object</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets the end date of the Order.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The End date of the Order</value>
        public DateTime EndDate { get; set; }

        /// <summary>
        ///     Gets the total price of the Order.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The total price of the Order</value>
        public decimal TotalPrice { get; set; }
    }
}