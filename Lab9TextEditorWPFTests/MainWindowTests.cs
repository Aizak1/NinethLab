using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLogicLibrary;

namespace TaskWPF.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void TextRedactorTest()
        {
            MainWindow redactor = new MainWindow();
            LabLogic logic = new LabLogic();
            string path = @"actual.txt";
            var expected = logic.GetDataFromFile(@"expected.txt");
            var actual = logic.GetDataFromFile(path);
            logic.SetFileFlag(true);
            logic.SaveData("111\n222\n333\n",path);
            actual = logic.GetDataFromFile(path);
            Assert.IsTrue(LabLogic.FileDataCompare(expected,actual));
            

        }
       
    }
}