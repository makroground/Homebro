using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebro.Views;

namespace Homebro.ViewModels
{
    class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menu
            Menu.Add(new MenuItem() { Glyph = "", Text = "Beleuchtung", NavigationDestination = typeof(FirstPage) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Sensoren", NavigationDestination = typeof(SecondPage) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Einstellungen", NavigationDestination = typeof(ThirdPage) });
        }
    }
}
