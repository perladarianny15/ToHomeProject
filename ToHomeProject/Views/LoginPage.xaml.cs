using System;
using System.Collections.Generic;
using ToHomeProject.ViewModels;
using Xamarin.Forms;

namespace ToHomeProject.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}
