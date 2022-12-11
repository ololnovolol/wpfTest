using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Commands
{
    /// <summary>
    ///     Interface command that is responsible for updating records.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IUpdateCommand
    {
        /// <summary>
        ///     Run command.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="model"> Contains BaseModel object</param>
        /// <returns>The Task object</returns>
        Task Execute(BaseModel model);
    }
}