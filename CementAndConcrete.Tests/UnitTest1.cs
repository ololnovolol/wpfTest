using CementAndConcrete.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CementAndConcrete.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=buildDb";

        [TestMethod]
        public void TestConnectToDb()
        {
            IList<MaterialDto> materials = new List<MaterialDto>();

            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new("SELECT * FROM Materials", connection);
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

            Assert.IsNotNull(materials);
        }
    }
}