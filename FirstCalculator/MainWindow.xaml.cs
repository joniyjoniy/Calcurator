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

namespace FirstCalculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Boolean isFirst = true;
        Decimal value1 = 0;
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (ope != Operator.NULL && isFirst)
            {
                value1 = Convert.ToDecimal(txtDisplay.Text);
                txtDisplay.Text = "0";
                isFirst = false;
            }

            String text = txtDisplay.Text +(string) ((Button)sender).Content;
            decimal d = Convert.ToDecimal(text);
            String text2 = d.ToString();
            txtDisplay.Text = text2;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.IndexOf(".") >= 0)
            {
                return;
            }
            txtDisplay.Text = txtDisplay.Text + ".";
        }

        enum Operator {
            NULL,
            ADD,
            SUB,
            MUL,
            DIV,
            EQU
        };

        Operator ope = Operator.NULL;

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            isFirst = true;
            ope = Operator.ADD;
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            isFirst = true;
            ope = Operator.SUB;
        }

        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            isFirst = true;
            ope = Operator.MUL;
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            isFirst = true;
            ope = Operator.DIV;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            decimal value2 = Convert.ToDecimal(txtDisplay.Text);
            decimal result = 0;

            switch (ope)
            {
                case Operator.ADD:
                    result = value1 + value2;
                    break;
                case Operator.SUB:
                    result = value1 - value2;
                    break;
                case Operator.MUL:
                    result = value1 * value2;
                    break;
                case Operator.DIV:
                    result = value1 / value2;
                    break;
            }
            isFirst = true;
            ope = Operator.EQU;

            txtDisplay.Text = result.ToString();
        }
    }
}
