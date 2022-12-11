using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CementAndConcrete.WPF.ViewModel.Base
{
    /// <summary>
    ///     Base View model of views.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     View change handler.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     When a class object changes the value of a property,
        ///     it notifies the system through the PropertyChanged event that the property has changed.
        ///     And the system updates all linked objects.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="propertyName">Contains the string value of the modified data name that the event generated.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Changes the contents of a property and notifies the system of changes to that property.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="field">Contains old value</param>
        /// <param name="value">Contains new value</param>
        /// <param name="propertyName">Contains the string value of the modified data name that the event generated.</param>
        /// <returns>Returns true if the property has been changed.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}