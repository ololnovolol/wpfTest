using System;
using System.Windows.Markup;

namespace CementAndConcrete.WPF.Extensions
{
    /// <summary>
    ///     Extension class for binding enums to comboboxElement.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public class BindingEnums : MarkupExtension
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BindingEnums" /> class..
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="enumType">Contains type of incoming enum element</param>
        public BindingEnums(Type enumType)
        {
            if (enumType is not { IsEnum: true })
            {
                throw new ArgumentNullException($"{EnumType} must not be null and of type enum");
            }

            EnumType = enumType;
        }

        /// <summary>
        ///     Gets or sets a EnumType object.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <value>The EnumType Object.</value>
        public Type EnumType { get; }

        /// <summary>
        ///     Gets enumTypeValues.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="serviceProvider">Contains incoming enum object</param>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}