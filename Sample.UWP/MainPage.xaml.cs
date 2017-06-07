using Sample.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sample.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly List<Person> _persons;

        public MainPage()
        {
            this.InitializeComponent();

            _persons = new List<Person>();
            for (int i = 0; i < 5; i++)
            {
                var person = new Person
                {
                    Id = i,
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i}"
                };

                _persons.Add(person);
            }
        }

        public List<Person> Persons => _persons;
    }
}
