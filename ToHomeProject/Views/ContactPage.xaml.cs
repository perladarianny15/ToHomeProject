using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ToHomeProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToHomeProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactPageViewModel();

        }
    }
}
