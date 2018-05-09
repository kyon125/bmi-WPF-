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

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        //宣告全域變數bmi
        public static double bmi;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void heightslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //抓取身高slider的值
            double value1 = Math.Round(heightslider.Value,1);
            heightnumber.Text = value1.ToString();
            
            //控制粉紅框的移動速度
            Canvas.SetLeft(heightborder, (value1 * 2) - 40);

            //計算bmi
            double H = double.Parse(heightnumber.Text);
            double W = double.Parse(weightnumber.Text);
            double bmi = (W / (H * H / 10000));
            BMIN1.Text = bmi.ToString();

            //將數字分為小數點前、後，2部分
            string[] parts = Math.Round(bmi,1).ToString().Split('.');

            //BMIN1顯示為小數點前數字
            BMIN1.Text = parts[0];

            //防止計算結果出現不能顯示的情形
            if (parts.Length > 1)
            {
                BMIN2.Text = "." + parts[1];
            }
            else
            {
                BMIN2.Text = ".0";
            }
        }

        private void weightslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //抓取體重slider的值
            double value2 = Math.Round(weightslider.Value, 1);
            weightnumber.Text = value2.ToString();

            //控制淺藍框的移動速度
            Canvas.SetLeft(weightborder, (value2 * 2.7) - 40);

            //計算bmi
            double H = double.Parse(heightnumber.Text);
            double W = double.Parse(weightnumber.Text);
            double bmi = (W / (H * H / 10000));
            BMIN1.Text = bmi.ToString();

            //將數字分為小數點前、後，2部分
            string[] parts = Math.Round(bmi, 1).ToString().Split('.');

            //BMIN1顯示為小數點前數字
            BMIN1.Text = parts[0];

            //防止計算結果出現不能顯示的情形
            if (parts.Length > 1)
            {
                BMIN2.Text = "." + parts[1];
            }
            else
            {
                BMIN2.Text = ".0";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //清空身高體重之值
            weightslider.Value = 0;
            heightslider.Value = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //判斷bmi之分區
            if (bmi < 18.5)
            {
                BMIN1.Text = "過輕";
            }
            else if (bmi > 18.5 && bmi < 24)
            {
                BMIN1.Text = " 體重正常";
            }
            else
            {
                BMIN1.Text = " 超重";
            }
            BMIN2.Text = "喔！";
        }
    }
}
