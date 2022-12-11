namespace CementAndConcrete.DAL.Entities.Base
{
    /// <summary>
    ///     Base class entity.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public abstract class BaseEntity
    {
        /// <summary>
        ///     Gets or sets the identifier of the Base entity model object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The identifier of the Base entity model object</value>
        public Guid Id { get; set; }
    }
}