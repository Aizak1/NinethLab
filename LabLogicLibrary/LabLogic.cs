using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace LabLogicLibrary
{
   
    public class LabLogic
    {
        private bool _fileIsChosen;
        public bool FileIsChosen => _fileIsChosen;
        public string GetStringPath()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text documents (.txt)| *.txt"
            };
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
              
        }

        public List<string> GetDataFromFile(string path)
        {
           
            
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    _fileIsChosen = true;
                    return File.ReadAllLines(path).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                _fileIsChosen = false;
                return new List<string>();
            }
        }
        public void SaveData(string text,string path)
        {
            if (_fileIsChosen)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(text);
                    }
                }
                catch (Exception exeption)
                {

                    MessageBox.Show(exeption.Message);
                }
                MessageBox.Show("The file was saved");

                
                _fileIsChosen = false;
            }
            else
            {
                MessageBox.Show("You don't choose the file");
            }
        }
        public void SetFileFlag(bool value)
        {
            _fileIsChosen = value;
        }

        public static bool FileDataCompare(List<string> data1,List<string> data2)
        {
            if (data1.Count != data2.Count)
                return false;
            for (int i = 0; i < data1.Count; i++)
            {
                if (data1[i] != data2[i])
                    return false;
            }
            return true;
        }

        
        

      
       

       
    }
}
