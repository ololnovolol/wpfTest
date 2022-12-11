using System;
using System.Windows.Input;

namespace CementAndConcrete.WPF.Commands
{
    /// <summary>
    ///     Base realization ICommand interface.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class ActionCommand : ICommand
    {
        /// <summary>
        ///     Contains Action methods.
        /// </summary>
        private readonly Action action;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionCommand" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="action">Contains Action method</param>
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        /// <summary>
        ///     Determines whether the given command can be executed in its current state.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="parameter">Data used by this command</param>
        /// <returns>Returns true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        ///     Specifies the method to be called when this command is invoked.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="parameter">Data used by this command</param>
        public void Execute(object? parameter)
        {
            action();
        }

        /// <summary>
        ///     Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}