using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using ToHomeProject.Models;
using ToHomeProject.ViewModels;
using Xamarin.Forms;

namespace ToHomeProject.Views
{
    public partial class ContactListPage : ContentPage
    {
        public ContactListPage()
        {
            InitializeComponent();
            BindingContext = new ContactPageListViewModel();

        }
    }
}
