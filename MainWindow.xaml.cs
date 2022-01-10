using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Calculator
{
    /// <summary>   
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        public MainWindow()
        {
            InitializeComponent();
            btn_ac.Click += Btn_ac_Click;
            btn_negative.Click += Btn_negative_Click;
            btn_percent.Click += Btn_percent_Click;
            btn_equal.Click += Btn_equal_Click;
        }

        private void Btn_equal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lb_result.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                ChangeResultLabel(lastNumber.ToString());
            }
        }

        private void Btn_negative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lb_result.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ChangeResultLabel(lastNumber.ToString());
            }
        }

        private void Btn_ac_Click(object sender, RoutedEventArgs e)
        {
            ChangeResultLabel("0");
        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("7");
        }

        public void ChangeResultLabel(string change)
        {
            lb_result.Content = change;
        }


        private void btn_divide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("8");
        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("9");
        }

        private void btn_times_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("4");
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("5");
        }

        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("6");
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("1");
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("2");
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("3");
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            AppendNumberToLabel("0");
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {

        }

        public void AppendNumberToLabel(string input)
        {
            string labelContent;
            if (lb_result.Content.ToString() == "0")
            {
                labelContent = input;
            }
            else
            {
                labelContent = $"{lb_result.Content}{input}";
            }
            ChangeResultLabel(labelContent);
        }
    }
}
