using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class Customers model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class Customer : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Customer" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="firstName">Contains first name value of the Customers object</param>
        /// <param name="lastName">Contains last name value of the Customers object</param>
        /// <param name="phone">Contains phone number value of the Customers object</param>
        /// <param name="country">Contains country value of the Customers object</param>
        /// <param name="city">Contains city value of the Customers object</param>
        /// <param name="street">Contains street address value of the Customers object</param>
        /// <param name="apartment">Contains apartment number maybe with letter value of the Customers object</param>
        public Customer(
            string firstName,
            string lastName,
            string phone,
            string country,
            string city,
            string street,
            string apartment)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.Apartment = apartment;
            this.Name = firstName + " " + lastName;
        }

        /// <summary>
        ///     Gets the first name of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The first name of the Customers object</value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets the last name of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The last name of the Customers object</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets the phone of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The phone of the Customers object</value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets the country of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The country of the Customers object</value>
        public string Country { get; set; }

        /// <summary>
        ///     Gets the city of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The city of the Customers object</value>
        public string City { get; set; }

        /// <summary>
        ///     Gets the street of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The street of the Customers object</value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets the apartment of the Customers object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The apartment of the Customers object</value>
        public string Apartment { get; set; }
    }
}