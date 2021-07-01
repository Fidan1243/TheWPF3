using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                TextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                TextBox1.Visibility = Visibility.Visible;
                t2.Text = openFileDialog.FileName;
                copy.IsEnabled = true;
                selectall.IsEnabled = true;
                cut.IsEnabled = true;
                save.IsEnabled = true;
                autos.IsEnabled = true;
                paste.IsEnabled = true;
            }
        }

        private void selectall_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Dispatcher.BeginInvoke(new Action(() =>
            {
                TextBox1.SelectAll();
            }));
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Copy();
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Paste();
        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Cut();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(filename, TextBox1.Text);
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            File.WriteAllText(filename, TextBox1.Text);
        }

        private void autos_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.TextChanged += TextBox1_TextChanged;
        }
    }
}
