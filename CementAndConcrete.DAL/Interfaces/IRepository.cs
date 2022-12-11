namespace CementAndConcrete.DAL.Interfaces
{
    /// <summary>
    ///     Interface provides an interface for CRUD operations on entities.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IRepository<T>
    {
        /// <summary>
        ///     Creates a record in the database based on the entity objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the entity objects</param>
        void Create(T item);

        /// <summary>
        ///     Removes the matching entry based on the input argument.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the entity objects</param>
        /// <returns>List of entity objects</returns>
        void Delete(Guid id);

        /// <summary>
        ///     Takes one record of the entity objects from the database by ID.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">Contains the identifier of the entity objects</param>
        /// <returns>The entity objects</returns>
        T Get(Guid id);

        /// <summary>
        ///     Takes all entity objects records from the database and returns a list of them.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of entity objects</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Update the matching entry based on the input argument.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">Contains the entity objects</param>
        void Update(T item);
    }
}