using System.Windows;

namespace Loim
{
    /// <summary>
    /// Interaction logic for Impressum.xaml
    /// </summary>
    public partial class Impressum : Window
    {
        public Impressum()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
