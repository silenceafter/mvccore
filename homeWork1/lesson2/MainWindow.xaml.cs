using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace lesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //
            //SleepValue, TimerValue
            int seconds = int.Parse(SleepValue.Text);
            TimerValue.Text = seconds.ToString();
            //таймер
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);            
            timer.Start();
            //          
            Thread one = new Thread(Fibonacci);
            one.Start();
        }

        public void Fibonacci()
        {
            int number1 = 0, number2 = 1;
            int cnt = 0, tmp;
            int milliseconds = 1000;
            //            
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
            new Action(() =>
            {
                milliseconds = int.Parse(SleepValue.Text) * 1000;
            }));

            while(cnt < 25)
            {    
                Thread.Sleep(milliseconds);                                     
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() =>
                {
                    ResultValue.Text += $"{ number1.ToString() } ";
                }));                
                //
                tmp = number2;//tmp = 1
                number2 += number1;//number2 = 1 + 0 = 1
                number1 = tmp;//number1 = tmp = 1
                cnt++;
            }     
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            int seconds = int.Parse(TimerValue.Text);
            //
            if (seconds > 0)
            {
                seconds--;                
            }
            else 
            {
                seconds = int.Parse(SleepValue.Text);
            }            
            TimerValue.Text = seconds.ToString();
        }
    }
}
