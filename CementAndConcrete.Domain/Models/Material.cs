using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class Material model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class Material : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Material" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="name">Contains name value of the Material object</param>
        /// <param name="amount">Contains amount value of the Material object</param>
        /// <param name="price">Contains price value of the Material object</param>
        public Material(string name, int amount, decimal price)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }

        /// <summary>
        ///     Gets the amount of the Material object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The amount of the Material object</value>
        public int Amount { get; set; }

        /// <summary>
        ///     Gets the price of the Material object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The price of the Material object</value>
        public decimal Price { get; set; }
    }
}