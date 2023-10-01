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
using Lib_5;
using LibMas;
//Дана целочисленная матрица размера M × N, элементы которой могут принимать
//значения от 0 до 100 Различные строки матрицы назовем похожими, если
//совпадают множества чисел, встречающихся в этих строках. Найти количество
//строк, похожих на первую строку данной матрицы.
namespace MDK3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] matrix; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Рубан Л. ИСП-31 Практическая работа №3:Дана целочисленная матрица размера M × N, элементы которой могут принимать\r\nзначения от 0 до 100 Различные строки матрицы назовем похожими, если\r\nсовпадают множества чисел, встречающихся в этих строках. Найти количество\r\nстрок, похожих на первую строку данной матрицы.");
        }

        private void Oчистить(object sender, RoutedEventArgs e)
        {
            str.Clear();
            stlb.Clear();
            pohstr.Clear();
            dt.Items.Clear();
           
        }

        private void dt_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;//определяем номер стобца
            int indexRow = e.Row.GetIndex();//определяем номер строки
            bool f1 = Int32.TryParse(str.Text, out int count1);
            bool f2 = Int32.TryParse(stlb.Text, out int count2);
            if (f1 == true && f2 == true)
            {
                matrix[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            else
            {
                MessageBox.Show("Ошибка, заполни ячейки числами");
            }
        }

        private void Пуск_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(str.Text, out int count1) && int.TryParse(stlb.Text, out int count2))
            {
                if (count1 > 0 && count2 > 0 )
                {
                    matrix = new int[count1, count2];
                    dt.ItemsSource = libmas.ToDataTable(matrix).DefaultView;
                }
                
            }
            else MessageBox.Show("Некоректное значение");

            pohstr.Clear();
            if (int.TryParse(str.Text,out int rows) && int.TryParse(stlb.Text, out int columns))
            {
                if (rows > 0 && columns > 0 )
                {
                    matrix = new int[rows, columns];
                    Random rnd = new Random();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                            matrix[i, j] = rnd.Next(0, 100);

                    }
                }
                //else MessageBox.Show("Некоректное значение");
                dt.ItemsSource = libmas.ToDataTable(matrix).DefaultView;
                Lib_5.Lib5.func(matrix, out int count3);
                pohstr.Text = Convert.ToString(count3);
            }
        }
    }
}
