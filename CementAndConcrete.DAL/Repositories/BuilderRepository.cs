using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.Domain.Enums;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Repositories
{
    /// <summary>
    ///     Storage class for BuilderDto objects.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class BuilderRepository : IRepository<BuilderDto>
    {
        /// <summary>
        ///     Contains SqlConnection object.
        /// </summary>
        private readonly SqlConnection connection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderRepository" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connection">Contains the SqlConnection object</param>
        public BuilderRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        ///     Creates a record in the database based on the BuilderDTO object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the BuilderDto object</param>
        public void Create(BuilderDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                const string query =
                    "INSERT INTO Builders(FirstName, LastName, Phone, Skill) VALUES(@firstname, @lastname, @phone, @skill)";
                SqlCommand cmd = new(query, this.connection);
                cmd.Parameters.AddWithValue("@firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@lastname", item.LastName);
                cmd.Parameters.AddWithValue("@phone", item.Phone);
                cmd.Parameters.AddWithValue("@skill", item.Skill);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Delete a record in the database based on the id BuilderDTO object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the BuilderDto object</param>
        public void Delete(Guid id)
        {
            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("DELETE FROM Builders WHERE Id = @id", this.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Takes one record of the BuilderDTO object from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the BuilderDto object</param>
        /// <returns>The BuilderDto object</returns>
        public BuilderDto Get(Guid id)
        {
            BuilderDto item = new();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Builders WHERE Id = @id", this.connection);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader? reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new BuilderDto
                    {
                        Id = reader.GetGuid(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Skill = this.GetSkillLevel(reader.GetString(4))
                    };
                }
            }

            return item;
        }

        /// <summary>
        ///     Takes all BuilderDTO object records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of BuilderDto object</returns>
        public IEnumerable<BuilderDto> GetAll()
        {
            var materials = new List<BuilderDto>();

            using (this.connection)
            {
                this.connection.Open();

                SqlCommand cmd = new("SELECT * FROM Builders", this.connection);
                SqlDataReader? reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    materials.Add(
                        new BuilderDto
                        {
                            Id = reader.GetGuid(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Skill = this.GetSkillLevel(reader.GetString(4))
                        });
                }
            }

            return materials;
        }

        /// <summary>
        ///     Update a record in the database based on the BuilderDTO object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the BuilderDto object</param>
        public void Update(BuilderDto item)
        {
            using (this.connection)
            {
                this.connection.Open();

                const string query =
                    "UPDATE Builders SET FirstName = @firstname, LastName = @lastname, Phone = @phone, Skill = @skill WHERE Id = @id";
                SqlCommand cmd = new(query, this.connection);

                cmd.Parameters.AddWithValue("@firstname", item.FirstName);
                cmd.Parameters.AddWithValue("@lastname", item.LastName);
                cmd.Parameters.AddWithValue("@phone", item.Phone);
                cmd.Parameters.AddWithValue("@skill", item.Skill.ToString());

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Get correct skill level for incoming value.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="value">Contains text value of skill level</param>
        /// <returns>Return Correct Enum variable for incoming value</returns>
        private SkillLevel GetSkillLevel(string value)
        {
            if (value.ToLower().Equals(SkillLevel.HIGHT.ToString().ToLower()))
            {
                return SkillLevel.LOW;
            }

            return value.ToLower().Equals(SkillLevel.MEDIUM.ToString().ToLower()) ? SkillLevel.MEDIUM : SkillLevel.LOW;
        }
    }
}