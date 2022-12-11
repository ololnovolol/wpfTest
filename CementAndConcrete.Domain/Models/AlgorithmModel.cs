using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class AlgorithmModel model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class AlgorithmModel : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AlgorithmModel" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="algorithms">Contains enum of algorithm variable</param>
        public AlgorithmModel(Algorithms algorithms)
        {
            this.Algorithms = algorithms;
            this.Name = algorithms.ToString();
        }

        /// <summary>
        ///     Gets the name of algorithm value.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The Algorithms enum value</value>
        public Algorithms Algorithms { get; set; }
    }
}