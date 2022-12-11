using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Repositories
{
    /// <summary>
    ///     Storage class for MaterialDto objects..
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class MaterialRepository : IRepository<MaterialDto>
    {
        /// <summary>
        ///     Contains SqlConnection object.
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaterialRepository" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connection">Contains SqlConnection object</param>
        public MaterialRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Creates a record in the database based on the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the MaterialDto object</param>
        public void Create(MaterialDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "INSERT INTO Materials(Name, Amount, Price) VALUES(@name, @amount, @price)",
                    this.connection);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Delete a record in the database based on the id MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the MaterialDto object</param>
        public void Delete(Guid id)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("DELETE FROM Materials WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Takes one record of the MaterialDto object from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the MaterialDto object</param>
        /// <returns>The MaterialDto object</returns>
        public MaterialDto Get(Guid id)
        {
            MaterialDto item = new();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Materials WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader? reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new MaterialDto
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Amount = reader.GetInt32(2),
                        Price = reader.GetDecimal(3)
                    };
                }
            }

            return item;
        }

        /// <summary>
        ///     Takes all MaterialDto object records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of MaterialDto object</returns>
        public IEnumerable<MaterialDto> GetAll()
        {
            var materials = new List<MaterialDto>();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Materials", this.connection);
                SqlDataReader? reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    materials.Add(
                        new MaterialDto
                        {
                            Id = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Amount = reader.GetInt32(2),
                            Price = reader.GetDecimal(3)
                        });
                }
            }

            return materials;
        }

        /// <summary>
        ///     Update a record in the database based on the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the MaterialDto object</param>
        public void Update(MaterialDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "UPDATE Materials SET Name = @name, Amount = @amount, Price = @price WHERE Id = @id",
                    this.connection);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@id", item.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}