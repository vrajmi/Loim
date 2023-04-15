using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Loim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer soundplayer = new SoundPlayer(@"../../Resources/Main-Theme.wav");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            soundplayer.PlayLooping();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            User UserWindow = new User();
            soundplayer.Stop();
            this.Hide();
            UserWindow.ShowDialog();
            this.Show();
        }

        private void ImpressumLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Impressum ImpressumWindow = new Impressum();
            ImpressumWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
