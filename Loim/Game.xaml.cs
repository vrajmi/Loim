using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Loim
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        static List<QuestionClass> list = new List<QuestionClass>();

        Random rnd = new Random();
        End EndWindow = new End();

        int Round = 0;

        char choice;
        int select = 0;

        int mp = 25;

        DispatcherTimer timer = new DispatcherTimer();

        SoundPlayer soundplayer = new SoundPlayer();

        static void Read()
        {
            StreamReader sr = new StreamReader("../../Resources/loim.txt");
            while (!sr.EndOfStream)
            {
                try
                {
                    list.Add(new QuestionClass(sr.ReadLine()));
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            sr.Close();
        }

        public Game()
        {
            InitializeComponent();
            Read();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += dispatcherTimer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_legyen_on_is_milliomos_focimdal.wav");

            soundplayer.Play();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            soundplayer.Stop();
            StartButton.Visibility = Visibility.Hidden;
            //Questionbox
            QuestionButton.IsEnabled = true;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            mp--;
            int perc = mp / 60;
            Timer.Content = perc.ToString() + ":" + mp % 60;
            if (mp < 11)
            {
                Timer.Foreground = System.Windows.Media.Brushes.Red;
            }
            if (mp == 0)
            {
                timer.Stop();
            }
            if (mp == 0)
            {
                StreamWriter file = new StreamWriter("../../Resources/money.txt");
                file.WriteLine("0 Ft");
                file.Close();

                this.Hide();
                EndWindow.ShowDialog();
                this.Close();
            }
        }

        /*
        private void Rounds()
        {
            switch (Round)
            {
                case 1:

                default:
                    break;
            }



            if (Round == 1)
            {
                panel1.BackColor = Color.Orange;
                label1.BackColor = Color.Orange;
                label12.BackColor = Color.Orange;
            }
            if (Round == 2)
            {
                panel13.BackColor = Color.Orange;
                label2.BackColor = Color.Orange;
                label15.BackColor = Color.Orange;
            }
            else if (Round == 3)
            {
                panel12.BackColor = Color.Orange;
                label3.BackColor = Color.Orange;
                label16.BackColor = Color.Orange;
            }
            else if (Round == 4)
            {
                panel11.BackColor = Color.Orange;
                label4.BackColor = Color.Orange;
                label17.BackColor = Color.Orange;
            }
            else if (Round == 5)
            {
                panel10.BackColor = Color.Orange;
                label5.BackColor = Color.Orange;
                label18.BackColor = Color.Orange;

                richTextBox1.Visible = true;
                pictureBox8.Visible = true;
                richTextBox1.Text = "Gratulálok! Kilépőponthoz erkeztünk, ha kilépni kivánsz és el vinni a 100.000 Ft nyomd meg a  a bal alsó sarokban a kilép gombot. Ha viszont folytatni akarod akkor nyomd meg a folytatást!";
                ImOut.Visible = true;
                Cont.Visible = true;
                tibi.Enabled = false;

                QuestionBox.Visible = false;

                Acaption.Visible = false;
                Bcaption.Visible = false;
                Ccaption.Visible = false;
                Dcaption.Visible = false;
                timer1.Stop();

            }
            else if (Round == 6)
            {
                ImOut.Visible = false;
                Cont.Visible = false;

                panel9.BackColor = Color.Orange;
                label6.BackColor = Color.Orange;
                label19.BackColor = Color.Orange;
            }
            else if (Round == 7)
            {
                panel8.BackColor = Color.Orange;
                label14.BackColor = Color.Orange;
                label20.BackColor = Color.Orange;
            }
            else if (Round == 8)
            {
                panel7.BackColor = Color.Orange;
                label7.BackColor = Color.Orange;
                label21.BackColor = Color.Orange;
            }
            else if (Round == 9)
            {
                panel6.BackColor = Color.Orange;
                label8.BackColor = Color.Orange;
                label22.BackColor = Color.Orange;
            }
            else if (Round == 10)
            {
                panel5.BackColor = Color.Orange;
                label9.BackColor = Color.Orange;
                label23.BackColor = Color.Orange;


                richTextBox1.Visible = true;
                pictureBox8.Visible = true;
                richTextBox1.Text = "Gratulálok! Folytatod vagy elviszed a 1.500.000 Ft?";
                ImOut.Visible = true;
                Cont.Visible = true;
                tibi.Enabled = false;

                QuestionBox.Visible = false;

                Acaption.Visible = false;
                Bcaption.Visible = false;
                Ccaption.Visible = false;
                Dcaption.Visible = false;

                timer1.Stop();
            }
            else if (Round == 11)
            {
                ImOut.Visible = false;
                Cont.Visible = false;
                panel4.BackColor = Color.Orange;
                label10.BackColor = Color.Orange;
                label24.BackColor = Color.Orange;
            }
            else if (Round == 12)
            {
                panel3.BackColor = Color.Orange;
                label11.BackColor = Color.Orange;
                label25.BackColor = Color.Orange;
            }
            else if (Round == 13)
            {
                panel15.BackColor = Color.Orange;
                label13.BackColor = Color.Orange;
                label26.BackColor = Color.Orange;
            }
            else if (Round == 14)
            {
                label30.BackColor = Color.Orange;
                panel17.BackColor = Color.Orange;
                label29.BackColor = Color.Orange;
            }
            else if (Round == 15)
            {
                panel16.BackColor = Color.Orange;
                label28.BackColor = Color.Orange;
                label27.BackColor = Color.Orange;
                Win.Visible = true;
                Win.Text = "Szép játék volt! Most már te is Milliomos vagy!";

                tibi.Enabled = false;
                timer1.Stop();

                QuestionBox.Visible = false;

                Acaption.Visible = false;
                Bcaption.Visible = false;
                Ccaption.Visible = false;
                Dcaption.Visible = false;
                StreamWriter file = new StreamWriter("../../Resources/money.txt");
                file.WriteLine("40.000.000 Ft");

                file.Close();


                this.Hide();
                f6.ShowDialog();
                this.Close();
            }
        }
        */

        private void QuestionButton_Click(object sender, RoutedEventArgs e)
        {
            soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_lets-play.wav");

            Question.Visibility = Visibility.Visible;

            //richTextBox1.Visible = false;

            Acaption.Visibility = Visibility.Visible; Acaption.Background = System.Windows.Media.Brushes.Black; Acaption.Foreground = System.Windows.Media.Brushes.White; Acaption.IsEnabled = true;
            Bcaption.Visibility = Visibility.Visible; Bcaption.Background = System.Windows.Media.Brushes.Black; Bcaption.Foreground = System.Windows.Media.Brushes.White; Bcaption.IsEnabled = true;
            Ccaption.Visibility = Visibility.Visible; Ccaption.Background = System.Windows.Media.Brushes.Black; Ccaption.Foreground = System.Windows.Media.Brushes.White; Ccaption.IsEnabled = true;
            Dcaption.Visibility = Visibility.Visible; Dcaption.Background = System.Windows.Media.Brushes.Black; Dcaption.Foreground = System.Windows.Media.Brushes.White; Dcaption.IsEnabled = true;
            List<int> Numbers = new List<int>();
            mp = 25;
            Timer.Foreground = System.Windows.Media.Brushes.Gold;
            timer.Start();

            /*
            Round++; //Kör 1-15
            Rounds();
            */

            for (int i = 1; i <= 15; i++)
            {
                do
                {
                    select = rnd.Next(0, list.Count);
                } while (Numbers.Contains(select));

                Numbers.Add(select);

                soundplayer.Play();

                Question.Content = list[select].Question;
                Acaption.Content = "A:   " + list[select].A;
                Bcaption.Content = "B:   " + list[select].B;
                Ccaption.Content = "C:   " + list[select].C;
                Dcaption.Content = "D:   " + list[select].D;
                DeveloperLabel.Content = list[select].Answer.ToString(); //for testing

                QuestionButton.IsEnabled = false;
                Halved.IsEnabled = true;
                Phone.IsEnabled = true;
                Community.IsEnabled = true;
            }
        }
    }
}
