using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LabLogicLibrary;

namespace TaskWPF
{
   
    public partial class MainWindow : Window
    {
        private LabLogic _executer = new LabLogic();
        private string _path;


        public MainWindow()
        {
            InitializeComponent();
            
        }
       
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text.Trim();
            _path = _executer.GetStringPath();
           List<string> formatedCoordinates = _executer.GetDataFromFile(_path);
            if (_executer.FileIsChosen)
            {
                OutputTextBox.IsEnabled = true;
                OutputTextBox.Clear();
                foreach (var line in formatedCoordinates)
                {
                    OutputTextBox.Text += $"{line}\n";
                }
            }
                
            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (_executer.FileIsChosen)
            {
                OutputTextBox.Clear();
            }
            else
            {
                MessageBox.Show("You don't choose the file");
            }
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _executer.SaveData(OutputTextBox.Text, _path);
            OutputTextBox.IsEnabled = false;
            OutputTextBox.Clear();
        }

        private void OutputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && OutputTextBox.IsEnabled)
            {
                OutputTextBox.Text += $"\n";
                OutputTextBox.SelectionStart = OutputTextBox.Text.Length-1;
            }
        }
    }
}
