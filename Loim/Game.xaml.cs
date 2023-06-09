﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
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

        private void Rounds()
        {
            switch (Round)
            {
                case 1:
                    Round1.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 2:
                    Round2.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 3:
                    Round3.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 4:
                    Round4.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 5:
                    Round5.Fill = System.Windows.Media.Brushes.Orange;
                    /*
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
                    */

                    break;
                case 6:
                    Round6.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 7:
                    Round7.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 8:
                    Round8.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 9:
                    Round9.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 10:
                    Round10.Fill = System.Windows.Media.Brushes.Orange;

                    /*
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
                    */

                    break;
                case 11:
                    Round11.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 12:
                    Round12.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 13:
                    Round13.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 14:
                    Round14.Fill = System.Windows.Media.Brushes.Orange;
                    break;
                case 15:
                    Round15.Fill = System.Windows.Media.Brushes.Orange;

                    /*
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
                    */

                    break;
                default:
                    break;
            }
        }

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

            Round++; //Kör 1-15
            Rounds();

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

        private void Acaption_Click(object sender, RoutedEventArgs e)
        {
            choice = 'A';

            for (int i = 0; i <= 15; i++)
            {
                if (choice == list[select].Answer)
                {
                    Acaption.Background = System.Windows.Media.Brushes.LightGreen;
                    Acaption.Foreground = System.Windows.Media.Brushes.Black;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_correct-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                }
                else
                {
                    Acaption.Background = System.Windows.Media.Brushes.Red;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_wrong-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                    StreamWriter file = new StreamWriter("../../Resources/money.txt");
                    file.WriteLine("0 Ft");
                    file.Close();

                    this.Hide();
                    EndWindow.ShowDialog();
                    this.Close();
                    break;
                }
            }
        }

        private void Bcaption_Click(object sender, RoutedEventArgs e)
        {
            choice = 'B';

            for (int i = 0; i <= 15; i++)
            {
                if (choice == list[select].Answer)
                {
                    Bcaption.Background = System.Windows.Media.Brushes.LightGreen;
                    Bcaption.Foreground = System.Windows.Media.Brushes.Black;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_correct-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                }
                else
                {
                    Bcaption.Background = System.Windows.Media.Brushes.Red;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_wrong-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                    StreamWriter file = new StreamWriter("../../Resources/money.txt");
                    file.WriteLine("0 Ft");
                    file.Close();

                    this.Hide();
                    EndWindow.ShowDialog();
                    this.Close();
                    break;
                }
            }
        }

        private void Ccaption_Click(object sender, RoutedEventArgs e)
        {
            choice = 'C';

            for (int i = 0; i <= 15; i++)
            {
                if (choice == list[select].Answer)
                {
                    Ccaption.Background = System.Windows.Media.Brushes.LightGreen;
                    Ccaption.Foreground = System.Windows.Media.Brushes.Black;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_correct-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                }
                else
                {
                    Ccaption.Background = System.Windows.Media.Brushes.Red;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_wrong-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                    StreamWriter file = new StreamWriter("../../Resources/money.txt");
                    file.WriteLine("0 Ft");
                    file.Close();

                    this.Hide();
                    EndWindow.ShowDialog();
                    this.Close();
                    break;
                }
            }
        }

        private void Dcaption_Click(object sender, RoutedEventArgs e)
        {
            choice = 'D';

            for (int i = 0; i <= 15; i++)
            {
                if (choice == list[select].Answer)
                {
                    Dcaption.Background = System.Windows.Media.Brushes.LightGreen;
                    Dcaption.Foreground = System.Windows.Media.Brushes.Black;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_correct-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                }
                else
                {
                    Dcaption.Background = System.Windows.Media.Brushes.Red;
                    timer.Stop();
                    soundplayer = new SoundPlayer(@"../../Resources/Kvizjatek_wrong-answer.wav");
                    soundplayer.Play();
                    QuestionButton.IsEnabled = true;
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                    StreamWriter file = new StreamWriter("../../Resources/money.txt");
                    file.WriteLine("0 Ft");
                    file.Close();

                    this.Hide();
                    EndWindow.ShowDialog();
                    this.Close();
                    break;
                }
            }
        }

        private void ImOut_Click(object sender, RoutedEventArgs e)
        {
            if (Round == 5)
            {
                StreamWriter file = new StreamWriter("../../Resources/money.txt");
                file.WriteLine("100.000 Ft");
                file.Close();
            }
            else if (Round == 10)
            {
                StreamWriter file = new StreamWriter("../../Resources/money.txt");
                file.WriteLine("1.500.000 Ft");
                file.Close();
            }

            this.Hide();
            EndWindow.Show();
            this.Close();
        }

        private void Cont_Click(object sender, RoutedEventArgs e)
        {
            QuestionButton.IsEnabled = true;
            /*
            pictureBox8.Visible = false;
            richTextBox1.Visible = false;
            */
        }

        private void Halved_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mp += 10;

            for (int i = 0; i <= 15; i++)
            {
                if ('A' != list[select].Answer && 'B' != list[select].Answer)
                {
                    Acaption.IsEnabled = false;
                    Bcaption.IsEnabled = false;
                }
                else if ('C' != list[select].Answer && 'D' != list[select].Answer)
                {
                    Ccaption.IsEnabled = false;
                    Dcaption.IsEnabled = false;
                }
            }

            Halved.Visibility = Visibility;
        }

        private void Phone_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mp += 10;
            //richTextBox1.Visible = true;

            int number = rnd.Next(1, 5);
            string answer;

            switch (number)
            {
                case 1:
                    answer = "Szerintem az A a helyes válasz.";
                    break;
                case 2:
                    answer = "Biztos vagyok abban hogy a B a helyes válasz.";
                    break;
                case 3:
                    answer = "Az én véleményem szerint a C lehet a helyes válasz.";
                    break;
                case 4:
                    answer = "Én a D-t választanám.";
                    break;
                default:
                    answer = "Nem tudom erre a választ.";
                    break;
            }

            Phone.Visibility = Visibility.Hidden;
            //richTextBox1.Text = answer;
        }

        private void Community_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*
            mp += 10;
            Ask.Visible = true;
            AskBack.Visible = true;
            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            progressBar4.Visible = true;
            progressBar1.Visible = true;
            Aska.Visible = true;
            Askb.Visible = true;
            Askc.Visible = true;
            Askd.Visible = true;
            AskBack.Visible = true;

            Community.Visible = false;
            */
        }
    }
}
