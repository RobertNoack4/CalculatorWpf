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
        SelectedOperator selectedOperator;
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
            double newNumber;
            if (double.TryParse(lb_result.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                }

                lb_result.Content = result.ToString();
            }
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

        public void ChangeResultLabel(string change)
        {
            lb_result.Content = change;
        }

        private void Number_btn_Click(object sender, RoutedEventArgs e)
        {
            string selectedValue = (sender as Button).Content.ToString();
            AppendNumberToLabel(selectedValue);
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lb_result.Content.ToString(), out lastNumber))
            {
                ChangeResultLabel("0");
            }

            if (sender == btn_times)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == btn_divide)
                selectedOperator = SelectedOperator.Division;
            if (sender == btn_plus)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btn_minus)
                selectedOperator = SelectedOperator.Subtraction;

        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if(lb_result.Content.ToString().Contains(","))
            {
                //Do nothing
            }
            else
            {
                lb_result.Content = $"{lb_result.Content},";
            }
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

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Subtraction(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                while(true)
                {
                    MessageBox.Show("Bist du bescheuert alter??????????? Was hast du gegen mein armes Programm? Was hat es dir angetan das du versuchst es zu verletzen? Ich hoffe du schämst dich in Grund und Boden du Programm Mord versucher!", "Arschloch vorm Bildschirm", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return 0;
            }
            return number1 / number2;
        }
    }
}
