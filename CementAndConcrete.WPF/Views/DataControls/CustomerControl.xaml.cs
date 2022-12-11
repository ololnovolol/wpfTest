using System.Text.RegularExpressions;
using System.Windows.Input;

namespace CementAndConcrete.WPF.Views.DataControls
{
    /// <summary>
    ///     Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomerControl" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public CustomerControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Check the entered characters for correctness according to the phone number.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="sender">Contains sender object</param>
        /// <param name="e">Contains selection event</param>
        private void Phone_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.-]+");
        }
    }
}