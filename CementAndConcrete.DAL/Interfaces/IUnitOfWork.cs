using CementAndConcrete.DAL.Entities;

namespace CementAndConcrete.DAL.Interfaces
{
    /// <summary>
    ///     Interface for interacting with repositories.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Gets the BuilderDto objects.
        /// </summary>
        public IRepository<BuilderDto> Builders { get; }

        /// <summary>
        ///     Gets the CustomerDto objects.
        /// </summary>
        public IRepository<CustomerDto> Consumers { get; }

        /// <summary>
        ///     Gets the MaterialDto objects.
        /// </summary>
        public IRepository<MaterialDto> Materials { get; }

        /// <summary>
        ///     Gets the OrderDto objects.
        /// </summary>
        public IRepository<OrderDto> Orders { get; }

        /// <summary>
        ///     Gets the TableDto objects.
        /// </summary>
        public IRepository<TableDto> Tables { get; }
    }
}