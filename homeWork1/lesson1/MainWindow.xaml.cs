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

namespace lesson1
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
            Thread one = new Thread(Fibonacci);
            one.Start(); 
        }

        public void Fibonacci()
        {
            int number1 = 0, number2 = 1;
            int tmp, cnt = 0;
                
            while(cnt < 25)
            {                                         
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, 
                new Action(() =>
                {
                    Simple.Text += $"{ number1.ToString() } ";
                }));
                Thread.Sleep(1000); 
                //
                tmp = number2;//tmp = 1
                number2 += number1;//number2 = 1 + 0 = 1
                number1 = tmp;//number1 = tmp = 1
                cnt++;                
            }        
        }
    }
}
