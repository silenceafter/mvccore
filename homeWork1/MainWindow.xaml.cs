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

namespace homeWork1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //textbox
            TextBox textbox1 = new TextBox();
            textbox1.Text = "Hello";
            stackPanel.Children.Add(textbox1);
            
            Thread one = new Thread(Fibonacci);
            one.Start();            
        }

        public void Fibonacci() 
        {
            Thread.Sleep(1000);
            
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                var ff = this.stackPanel;// = "Updated from another thread!"; 
                foreach(var Child in stackPanel.Children)
                {
                    MessageBox.Show(Child.ToString());
                }
                Simple.Text = "777";
                //MessageBox.Show(stackPanel.Children.textbox1.Text);
                //textbox.Text = textbox.Text + "Updated from another thread!";
            }));
        }
    }
}
