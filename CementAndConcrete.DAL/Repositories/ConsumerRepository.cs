using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Repositories
{
    /// <summary>
    ///     Storage class for CustomerDto objects..
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class ConsumerRepository : IRepository<CustomerDto>
    {
        /// <summary>
        ///     Contains SqlConnection object.
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConsumerRepository" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connection">Contains SqlConnection object</param>
        public ConsumerRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Creates a record in the database based on the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the CustomerDto object</param>
        public void Create(CustomerDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "INSERT INTO Consumers(FirstName, LastName, Phone, Country, City, Street, Apartment)" +
                    " VALUES(@firstname, @lastname, @phone, @country, @city, @street, @apartment)",
                    this.connection);

                cmd.Parameters.AddWithValue("@firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@lastname", item.LastName);
                cmd.Parameters.AddWithValue("@phone", item.Phone);
                cmd.Parameters.AddWithValue("@country", item.Country);
                cmd.Parameters.AddWithValue("@city", item.City);
                cmd.Parameters.AddWithValue("@street", item.Street);
                cmd.Parameters.AddWithValue("@apartment", item.Apartment);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Delete a record in the database based on the id CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the CustomerDto object</param>
        public void Delete(Guid id)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("DELETE FROM Consumers WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Takes one record of the CustomerDto object from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the CustomerDto object</param>
        /// <returns>The CustomerDto object</returns>
        public CustomerDto Get(Guid id)
        {
            CustomerDto item = new();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Consumers WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader? reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new CustomerDto
                    {
                        Id = reader.GetGuid(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Country = reader.GetString(4),
                        City = reader.GetString(5),
                        Street = reader.GetString(6),
                        Apartment = reader.GetString(7)
                    };
                }
            }

            return item;
        }

        /// <summary>
        ///     Takes all CustomerDto object records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of CustomerDto object</returns>
        public IEnumerable<CustomerDto> GetAll()
        {
            var materials = new List<CustomerDto>();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "SELECT Id, IIF(FirstName IS NULL OR FirstName = ' ', 'empty', FirstName), " +
                    "IIF(LastName IS NULL OR LastName = ' ', 'empty', LastName)," +
                    "Phone, Country, City, Street, Appartment" +
                    " From Customers",
                    this.connection);
                SqlDataReader? reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    materials.Add(
                        new CustomerDto
                        {
                            Id = reader.GetGuid(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Country = reader.GetString(4),
                            City = reader.GetString(5),
                            Street = reader.GetString(6),
                            Apartment = reader.GetString(7)
                        });
                }
            }

            return materials;
        }

        /// <summary>
        ///     Update a record in the database based on the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the CustomerDto object</param>
        public void Update(CustomerDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "UPDATE Consumers SET " +
                    "FirstName = @firstname, LastName = @lastname, Phone = @phone " +
                    "Country = @country, City = @city, Street = @street, Apartment = @apartment" +
                    "WHERE Id = @id",
                    this.connection);

                cmd.Parameters.AddWithValue("@firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@lastname", item.LastName);
                cmd.Parameters.AddWithValue("@phone", item.Phone);
                cmd.Parameters.AddWithValue("@country", item.Country);
                cmd.Parameters.AddWithValue("@city", item.City);
                cmd.Parameters.AddWithValue("@street", item.Street);
                cmd.Parameters.AddWithValue("@apartment", item.Apartment);

                cmd.ExecuteNonQuery();
            }
        }
    }
}