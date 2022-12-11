namespace CementAndConcrete.BLL.Interfaces
{
    /// <summary>
    ///     An interface for transforming a model into an entity, is a management service for the legacy entity repository.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IServiceBase<T> where T : class
    {
        /// <summary>
        ///     Interacts with the required Create method in the specific repository.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The base model object</param>
        void Create(T item);

        /// <summary>
        ///     Interacts with the required Update method in the specific repository.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="item">The base model object</param>
        void Update(T item);

        /// <summary>
        ///     Interacts with the required Delete method in the specific repository..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        void Delete(Guid id);

        /// <summary>
        ///     Interacts with the required GetAll method in the specific repository..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>List of Table objects</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        ///     Interacts with the required Get method in the specific repository..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="id">The base model object identifier</param>
        /// <returns>The Table object</returns>
        T Get(Guid id);
    }
}