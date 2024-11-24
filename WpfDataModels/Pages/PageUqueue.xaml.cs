using System;
using System.Collections;
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
using WpfDataModels.Models;

namespace WpfDataModels.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class PageUqueue : Page
    {
        private List<String> fruits = new List<String>() { "Alma", "Körte", "Szilva", "Narancs", "Banán", "Füge", "Kókusz" };
        private Uqueue<String> _queue;
        private Style itemEmptyStyle = new Style(typeof(ListViewItem));
        private Style itemStyle = new Style(typeof(ListViewItem));


        public PageUqueue()
        {
            InitializeComponent();
            _queue = new Uqueue<String>(10);

            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BorderThicknessProperty, new Thickness(1)));
            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BorderBrushProperty, Brushes.Black));
            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Red));



            itemStyle.Setters.Add(new Setter(ListViewItem.BorderThicknessProperty, new Thickness(1)));
            itemStyle.Setters.Add(new Setter(ListViewItem.BorderBrushProperty, Brushes.Black));
            itemStyle.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Yellow));

            DisplayUqueue();
            UpdateStatusBar("", "");
        }

        public Uqueue<string> ViewUqueue { get => _queue; }

        public void DisplayUqueue()
        {
            lvElements.Items.Clear();
            String statusNow = _queue.DevGetElements();
            var elements = statusNow.Split(';');

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                ListViewItem listItem = new();
                listItem.Content = elements[i];
                listItem.Style = elements[i] == "" ? itemEmptyStyle : itemStyle;
                lvElements.Items.Add(listItem);
            }

        }

        private void UpdateStatusBar(string method, string element)
        {
            sbiLastElement.Content = element;
            sbiLastMethod.Content = method;
            sbiCount.Content = _queue.Count;
        }

        private void btnUstack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            RandomFill();
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            if (txtElement.Text.Length == 0)
            {
                MessageBox.Show("Enter a word!");
                return;
            }
            try
            {
                _queue.Push(txtElement.Text);
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
            UpdateStatusBar($"Push(\"{txtElement.Text}\")", txtElement.Text);
            DisplayUqueue();
        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {
            String popResult = "";
            try
            {
                popResult = _queue.Pop();
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
            UpdateStatusBar("■ Pop()", popResult);
            DisplayUqueue();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _queue.Clear();
            UpdateStatusBar("Clear()", "");
            DisplayUqueue();
        }

        private void RandomFill()
        {
            Random rnd = new Random();
            _queue.Clear();
            var tempFruit = fruits.ToList();
            while (tempFruit.Count > 0)
            {
                int index = rnd.Next(tempFruit.Count);
                _queue.Push(tempFruit[index]);
                tempFruit.RemoveAt(index);
            }
            UpdateStatusBar("RANDOM Push(■)", "");
            DisplayUqueue();
        }

        private void btnPush_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
