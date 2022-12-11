using CementAndConcrete.DAL.Entities.Base;
using CementAndConcrete.Domain.Enums;

namespace CementAndConcrete.DAL.Entities
{
    /// <summary>
    ///     Class BuilderDto model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class BuilderDto : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the first name of the BuilderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The first name of the BuilderDto object</value>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the last name of the BuilderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The last name of the BuilderDto object</value>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the phone of the BuilderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The phone of the BuilderDto object</value>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the skill level of the BuilderDto object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The skill level of the BuilderDto object</value>
        public SkillLevel Skill { get; set; } = default;
    }
}