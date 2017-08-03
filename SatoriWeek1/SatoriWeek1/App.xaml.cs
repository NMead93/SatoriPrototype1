using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SatoriWeek1
{
    public partial class App : Application
    {
        public App(string fileName)
        {
            InitializeComponent();

            ItemRepository.Initialize(fileName);

            MainPage = new NavigationPage(new SatoriWeek1.MainPage());
        }
    }
}
