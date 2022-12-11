using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Enums;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Repositories
{
    /// <summary>
    ///     Storage class for TableDto objects..
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class TablesRepository : IRepository<TableDto>
    {
        /// <summary>
        ///     Contains SqlConnection object.
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TablesRepository" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connection">Contains SqlConnection object</param>
        public TablesRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Creates a record in the database based on the TableDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void Create(TableDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "CREATE TABLE @tableName (@value1, @value2);",
                    this.connection);
                cmd.Parameters.AddWithValue("@value1", item.Id);
                cmd.Parameters.AddWithValue("@value2", item.Name);
                cmd.Parameters.Add(new SqlParameter("@tableName", item.Name));

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Deletes a record in the database by the given identifier.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the TableDto object</param>
        public void Delete(Guid id)
        {
            using (this.connection)
            {
                this.connection.Open();
                TableDto table = this.Get(id);
                SqlCommand cmd = new("DROP TABLE @tableName;", this.connection);
                cmd.Parameters.Add(new SqlParameter("@tableName", table.Name));
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Takes one record of the TableDto object from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the TableDto object</param>
        /// <returns>The TableDto object</returns>
        public TableDto Get(Guid id)
        {
            TableDto table = new();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "SELECT * FROM information_schema.tables WHERE TABLE_TYPE = 'BASE TABLE' WHERE Id = @id",
                    this.connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader? reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return table;
                }

                string? name = reader.GetString(2);
                table = new TableDto { Id = new Guid(), Name = name, Category = GetCategory(name) };
            }

            return table;
        }

        /// <summary>
        ///     Takes all TableDto object records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of TableDto object</returns>
        public IEnumerable<TableDto> GetAll()
        {
            var tables = new List<TableDto>();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "SELECT * FROM information_schema.tables WHERE TABLE_TYPE = 'BASE TABLE'",
                    this.connection);
                SqlDataReader? reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string? nameOfTable = reader.GetString(2);

                    if (nameOfTable.Contains('_'))
                    {
                        continue;
                    }

                    if (!char.IsUpper(reader.GetString(2).FirstOrDefault()))
                    {
                        continue;
                    }

                    string? name = reader.GetString(2);

                    tables.Add(
                        new TableDto { Id = new Guid(), Name = name, Category = GetCategory(name) });
                }
            }

            return tables;
        }

        /// <summary>
        ///     Update a record in the database based on the TableDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the TableDto object</param>
        public void Update(TableDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new(
                    "UPDATE @tableName SET id=@value1, name=@value2;",
                    this.connection);

                cmd.Parameters.AddWithValue("@value1", item.Id);
                cmd.Parameters.AddWithValue("@value2", item.Name);
                cmd.Parameters.Add(new SqlParameter("@tableName", item.Name));

                cmd.ExecuteNonQuery();
            }
        }

        private static TableCategories GetCategory(string name)
        {
            return name switch
            {
                "Customers" => TableCategories.Customers,
                "Materials" => TableCategories.Materials,
                "Builders" => TableCategories.Builders,
                "Orders" => TableCategories.Orders,
                _ => TableCategories.Default
            };
        }
    }
}