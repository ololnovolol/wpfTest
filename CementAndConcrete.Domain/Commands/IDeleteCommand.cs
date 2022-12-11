namespace CementAndConcrete.Domain.Commands
{
    /// <summary>
    ///     Interface command that is responsible for deleting records.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IDeleteCommand
    {
        /// <summary>
        ///     Run command.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="model"> Contains BaseModel object</param>
        /// <returns>The Task object</returns>
        Task Execute(Guid id);
    }
}