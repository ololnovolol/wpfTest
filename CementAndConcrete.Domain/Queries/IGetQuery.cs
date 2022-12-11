using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Queries
{
    /// <summary>
    ///     Interface query for get data from database.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IGetQuery
    {
        /// <summary>
        ///     Run query.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>The Task object</returns>
        Task<BaseModel> Execute();
    }
}