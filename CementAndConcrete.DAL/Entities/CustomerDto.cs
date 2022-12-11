using CementAndConcrete.DAL.Entities.Base;

namespace CementAndConcrete.DAL.Entities
{
    /// <summary>
    ///     Class CustomerDto model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class CustomerDto : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the first name of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The first name of the CustomerDto object</value>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the last name of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The last name of the CustomerDto object</value>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the phone of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The phone of the CustomerDto object</value>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the country of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The country of the CustomerDto object</value>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the city of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The city of the CustomerDto object</value>
        public string City { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the street of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The street of the CustomerDto object</value>
        public string Street { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the apartment of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The apartment of the CustomerDto object</value>
        public string Apartment { get; set; } = string.Empty;
    }
}