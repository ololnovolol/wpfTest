using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Queries
{
    /// <summary>
    ///     Describes a class that is able to fetch group of data from database.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public interface IGetAllQuery
    {
        /// <summary>
        ///     Run query.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>The List of Task object</returns>
        Task<IEnumerable<BaseModel>> Execute();
    }
}