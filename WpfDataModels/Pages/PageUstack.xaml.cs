using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageUstack : Page
    {

        private List<String> fruits = new List<String>() { "Alma", "Körte", "Szilva", "Narancs", "Banán", "Füge", "Kókusz" };
        private Ustack<String> _stack;
        private Style itemEmptyStyle = new Style(typeof(ListViewItem));
        private Style itemStyle = new Style(typeof(ListViewItem));

        public PageUstack()
        {
            InitializeComponent();

            _stack = new Ustack<String>(10);

            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BorderThicknessProperty, new Thickness(1)));
            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BorderBrushProperty, Brushes.Black));
            itemEmptyStyle.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Red));



            itemStyle.Setters.Add(new Setter(ListViewItem.BorderThicknessProperty, new Thickness(1)));
            itemStyle.Setters.Add(new Setter(ListViewItem.BorderBrushProperty, Brushes.Black));
            itemStyle.Setters.Add(new Setter(ListViewItem.BackgroundProperty, Brushes.Yellow));

            DisplayUstack();
            UpdateStatusBar("", "");


        }

        public void DisplayUstack()
        {
            lvElements.Items.Clear();
            String statusNow = _stack.DevGetElements();
            var elements = statusNow.Split(';');

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                ListViewItem listItem = new();
                listItem.Content = elements[i];
                listItem.Style = elements[i] == "" ? itemEmptyStyle : itemStyle;
                lvElements.Items.Add(listItem);
            }

        }
        public String StringRepresentation => _stack.ToString();
        public Ustack<string> ViewUstack { get => _stack; }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            if (txtElement.Text.Length == 0)
            {
                MessageBox.Show("Enter a word!");
                return;
            }

            try
            {
                _stack.Push(txtElement.Text);
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
            UpdateStatusBar($"Push(\"{txtElement.Text}\")", txtElement.Text);
            DisplayUstack();
        }

        private void UpdateStatusBar(string method, string element)
        {
            sbiLastElement.Content = element;
            sbiLastMethod.Content = method;
            sbiCount.Content = _stack.Count;
        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {
            String popResult = "";
            try
            {
                popResult = _stack.Pop();
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
            UpdateStatusBar("■ Pop()", popResult);
            DisplayUstack();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _stack.Clear();
            UpdateStatusBar("Clear()", "");
            DisplayUstack();
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            RandomFill();

        }

        private void RandomFill()
        {
            Random rnd = new Random();
            _stack.Clear();
            var tempFruit = fruits.ToList();
            while (tempFruit.Count > 0)
            {
                int index = rnd.Next(tempFruit.Count);
                _stack.Push(tempFruit[index]);
                tempFruit.RemoveAt(index);
            }
            UpdateStatusBar("RANDOM Push(■)", "");
            DisplayUstack();
        }
    }
}
