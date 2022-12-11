using System.Text.RegularExpressions;
using System.Windows.Input;

namespace CementAndConcrete.WPF.Views.DataControls
{
    /// <summary>
    ///     Interaction logic for BuilderControl.xaml
    /// </summary>
    public partial class BuilderControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderControl" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public BuilderControl()
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