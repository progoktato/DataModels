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

        AImatrix bitmap;

        public MainWindow()
        {
            InitializeComponent();

            AImatrix valos = new AImatrix(5);
            valos.FillRandomFloat(-10000, 10000);
            txtMatrix.Text = valos.ToString("5*5-ös mátrix");

            AImatrix matrixA = new AImatrix(3, 5);
            matrixA.FillRandomInt(-1000, 2000);
            txtMatrix.Text+= matrixA.ToString("A mátrix");

            AImatrix matrixB = new AImatrix(3, 5);
            matrixB.FillRandomInt(-1000, 2000);
            txtMatrix.Text+= matrixB.ToString("B mátrix");

            matrixA.Add(matrixB);
            txtMatrix.Text+= matrixA.ToString("A + B eredménye A-ban");


            bitmap=new AImatrix(6, 12);
            bitmap.FillRandomInt(0, 256);
            txtMatrix.Text += bitmap.ToString("BITMAP");

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

        private void btnToRight_Click(object sender, RoutedEventArgs e)
        {
            bitmap.RotateToRight();
            txtMatrix.Text += bitmap.ToString("BITMAP elforgatása jobbra");
            scrollViewer.ScrollToEnd();
        }

        private void btnToTop_Click(object sender, RoutedEventArgs e)
        {
            bitmap.RotateToUp();
            txtMatrix.Text += bitmap.ToString("BITMAP elforgatása felfelé");
            scrollViewer.ScrollToEnd();
        }

        private void btnToBottom_Click(object sender, RoutedEventArgs e)
        {
            bitmap.RotateToDown();
            txtMatrix.Text += bitmap.ToString("BITMAP elforgatása lefelé");
            scrollViewer.ScrollToEnd();
        }

        private void btnToLeft_Click(object sender, RoutedEventArgs e)
        {
            bitmap.RotateToLeft();
            txtMatrix.Text += bitmap.ToString("BITMAP elforgatása balra");
            scrollViewer.ScrollToEnd();
        }
    }
}