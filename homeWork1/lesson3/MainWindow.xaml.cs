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

namespace lesson3
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

            //прерывание
            try
            {
                one.Interrupt();    
            } 
            catch (Exception e)
            {
                MessageBox.Show($"исключение из главного потока {e.Message}");
            }
                   
            //сообщение об исключении не будет, если поток не блокируется (если убрать Thread.Sleep)
            MessageBox.Show("дальнейшие действия");
        }

        public void Fibonacci()
        {             
            try 
            {
                Thread.Sleep(Timeout.Infinite);                                     
            }
            catch(Exception e)
            {
                MessageBox.Show($"исключение из созданного потока {e.Message}");
            }                                                
        }       
    }
}
