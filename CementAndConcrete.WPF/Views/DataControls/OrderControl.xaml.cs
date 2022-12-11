using System.Text.RegularExpressions;
using System.Windows.Input;

namespace CementAndConcrete.WPF.Views.DataControls
{
    /// <summary>
    ///     Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderControl" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public OrderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Check the entered characters for correctness according to the number.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="sender">Contains sender object</param>
        /// <param name="e">Contains selection event</param>
        private void Phone_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}