using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.Connections
{
    /// <summary>
    ///     Class DbConnection.Establishes a connection to the database.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class DbConnection
    {
        /// <summary>
        ///     Contains connection path into db.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbConnection" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connectionString">Contains path value to connect database</param>
        public DbConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        ///     Establishes a connection to the database.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>SqlConnection object connect to database</returns>
        public SqlConnection ConnectToDatabase() => new(this.connectionString);
    }
}