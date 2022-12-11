using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Repositories
{
    /// <summary>
    ///     Storage class for OrderDto objects.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class OrderRepository : IRepository<OrderDto>
    {
        /// <summary>
        ///     Contains SqlConnection object.
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderRepository" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connection">Contains SqlConnection object</param>
        public OrderRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Creates a record in the database based on the OrderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void Create(OrderDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "INSERT INTO Orders(CustomerId, StartDate, EndDate, TotalPrice)" +
                    " VALUES(@consumerId, @startDate, @endDate, @totalPrice)",
                    this.connection);

                cmd.Parameters.AddWithValue("@consumerId", item.CustomerId);
                cmd.Parameters.AddWithValue("@startDate", item.StartDate);
                cmd.Parameters.AddWithValue("@endDate", item.EndDAte);
                cmd.Parameters.AddWithValue("@totalPrice", item.TotalPrice);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Delete a record in the database based on the id OrderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the OrderDto object</param>
        public void Delete(Guid id)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("DELETE FROM Orders WHERE Id = @id", this.connection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Takes one record of the OrderDto object from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the OrderDto object</param>
        /// <returns>The OrderDto object</returns>
        public OrderDto Get(Guid id)
        {
            OrderDto item = new();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Orders WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader? reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new OrderDto
                    {
                        Id = reader.GetGuid(0),
                        CustomerId = reader.GetGuid(1),
                        StartDate = reader.GetDateTime(2),
                        EndDAte = reader.GetDateTime(3),
                        TotalPrice = reader.GetDecimal(4)
                    };
                }
            }

            return item;
        }

        /// <summary>
        ///     Takes all OrderDto object records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of OrderDto object</returns>
        public IEnumerable<OrderDto> GetAll()
        {
            var materials = new List<OrderDto>();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Orders", this.connection);
                SqlDataReader? reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    materials.Add(
                        new OrderDto
                        {
                            Id = reader.GetGuid(0),
                            CustomerId = reader.GetGuid(1),
                            StartDate = reader.GetDateTime(2),
                            EndDAte = reader.GetDateTime(3),
                            TotalPrice = reader.GetDecimal(4)
                        });
                }
            }

            return materials;
        }

        /// <summary>
        ///     Update a record in the database based on the OrderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the OrderDto object</param>
        public void Update(OrderDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "UPDATE Orders SET " +
                    "CustomerId = @consumerId, StartDate = @startDate, EndDAte = @endDate " +
                    "TotalPrice = @totalPrice WHERE Id = @id",
                    this.connection);

                cmd.Parameters.AddWithValue("@consumerId", item.CustomerId);
                cmd.Parameters.AddWithValue("@startDate", item.StartDate);
                cmd.Parameters.AddWithValue("@endDate", item.EndDAte);
                cmd.Parameters.AddWithValue("@totalPrice", item.TotalPrice);

                cmd.ExecuteNonQuery();
            }
        }
    }
}