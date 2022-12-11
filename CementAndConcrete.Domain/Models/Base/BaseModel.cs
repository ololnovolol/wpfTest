namespace CementAndConcrete.Domain.Models.Base
{
    /// <summary>
    ///     Class Base model class/
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public abstract class BaseModel
    {
        /// <summary>
        ///     Gets the identifier of the Base model object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The identifier of the Base model object</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the BaseModel object
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>Name of BaseModel object</value>
        public string Name { get; set; } = string.Empty;
    }
}