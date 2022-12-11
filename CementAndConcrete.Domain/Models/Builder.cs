using CementAndConcrete.Domain.Enums;
using CementAndConcrete.Domain.Models.Base;

namespace CementAndConcrete.Domain.Models
{
    /// <summary>
    ///     Class Builder model
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class Builder : BaseModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Builder" /> class
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="firstName">Contains first name value of the Builder object</param>
        /// <param name="lastName">Contains last name value of the Builder object</param>
        /// <param name="phone">Contains phone number value of the Builder object</param>
        /// <param name="skill">Contains skill level value of the Builder object</param>
        public Builder(string firstName, string lastName, string phone, SkillLevel skill)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Skill = skill;
            this.Name = firstName + " " + lastName;
        }

        /// <summary>
        ///     Gets the first name of the Builder object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The first name of the Builder object</value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets the last name of the Builder object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The last name of the Builder object</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets the phone of the Builder object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The phone of the Builder object</value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets the skill level of the Builder object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The skill level of the Builder object</value>
        public SkillLevel Skill { get; set; }
    }
}