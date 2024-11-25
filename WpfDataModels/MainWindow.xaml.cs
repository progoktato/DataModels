using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataModels.Models;
using WpfDataModels.Pages;

namespace WpfDataModels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page pUstack = new PageUstack();
        private Page pUqueue = new PageUqueue();
        private Page pUset = new PageUset();


        public MainWindow()
        {
            InitializeComponent();

            AImatrix matrix = new AImatrix(3, 5);
            matrix.FillRandomInt(-1000, 2000);
            txtMatrix.Text = matrix.ToString("[A] mátrix");

            AImatrix matrixB = new AImatrix(3, 5);
            matrixB.FillRandomInt(-1000, 2000);
            txtMatrix.Text+= '\n'+matrixB.ToString("[B] mátrix");

            matrix.Add(matrixB);
            txtMatrix.Text+= '\n' + matrix.ToString("[A] = [A + B] eredménye");


            matrix.RotateToLeft();
            txtMatrix.Text += '\n' + matrix.ToString("[A] elforgatása balra");

            MainFrame.Navigate(new PageUstack());

        }

        private void btnUstack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(pUstack);
        }

        private void btnUqueue_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(pUqueue);
        }

        private void btnUset_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(pUset);
        }
    }
}