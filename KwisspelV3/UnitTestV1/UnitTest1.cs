using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KwisspelV3.ViewModel;
using KwisspelV3.Database;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace UnitTestV1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainViewModel Main = new MainViewModel();
           int v =  Main.context.Vragen.Count();
          
            Assert.AreEqual(Main.Vragen.Count(),v, "Het aantal objecten in de database zijn gelijk aan het aantal Vragen in de Vragen lijst");
        }

       [TestMethod]
      public void AddVraag()
        {
           

            MainViewModel Main = new MainViewModel();
            int a = Main.Vragen.Count;

            Main.SelectedVraag.Tekst = "Hoi";
            Main.SelectedCategorie.SoortName = "Taal";
            Main.SaveVraag();

            int b = Main.Vragen.Count;

            Assert.AreEqual((a + 1), b);

        }
        
    }
}
