using CementAndConcrete.DAL.Entities;
using CementAndConcrete.DAL.Interfaces;
using CementAndConcrete.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace CementAndConcrete.DAL.UnitOfWorks
{
    /// <summary>
    ///     Generic class for interacting with repositories.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Contains BuilderRepository object.
        /// </summary>
        private readonly BuilderRepository buildersRepo = null!;

        /// <summary>
        ///     Contains path to database.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        ///     Contains ConsumerRepository object.
        /// </summary>
        private readonly ConsumerRepository consumersRepo = null!;

        /// <summary>
        ///     Contains MaterialRepository object.
        /// </summary>
        private readonly MaterialRepository materialsRepo = null!;

        /// <summary>
        ///     Contains OrderRepository object.
        /// </summary>
        private readonly OrderRepository ordersRepo = null!;

        /// <summary>
        ///     Contains TablesRepository object.
        /// </summary>
        private readonly TablesRepository tablesRepo = null!;

        /// <summary>
        ///     Holds the value indicating whether current object is disposed or not.
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="connectionString">Contains the path value to connect database</param>
        public UnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        ///     Gets the Repository of the MaterialDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Repository of the MaterialDto object</value>
        public IRepository<MaterialDto> Materials
            => this.materialsRepo ?? new MaterialRepository(new SqlConnection(this.connectionString));

        /// <summary>
        ///     Gets the Repository of the TableDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Repository of the TableDto object</value>
        public IRepository<TableDto> Tables
            => this.tablesRepo ?? new TablesRepository(new SqlConnection(this.connectionString));

        /// <summary>
        ///     Gets the Repository of the BuilderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Repository of the BuilderDto object</value>
        public IRepository<BuilderDto> Builders
            => this.buildersRepo ?? new BuilderRepository(new SqlConnection(this.connectionString));

        /// <summary>
        ///     Gets the Repository of the CustomerDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Repository of the CustomerDto object</value>
        public IRepository<CustomerDto> Consumers
            => this.consumersRepo ?? new ConsumerRepository(new SqlConnection(this.connectionString));

        /// <summary>
        ///     Gets the Repository of the OrderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Repository of the OrderDto object</value>
        public IRepository<OrderDto> Orders
            => this.ordersRepo ?? new OrderRepository(new SqlConnection(this.connectionString));

        /// <summary>
        ///     Clears memory of unmanageable resources.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Clears memory after destroy this object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     Changes the value of the disposed field of UnitOfWork object
        ///     to the opposite and is called by the destructor automatically.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="disposing">Bool value contains result if Dispose method has been started</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing) { }

            this.disposed = true;
        }
    }
}